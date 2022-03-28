using combit.Reporting;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace combit.RedmineReports
{
    public partial class RedmineReportsForm : Form
    {
        ListLabel _lL;
        string connString;
        RedmineMySqlDataAccess _dataAccess;
        private static RegistryKey installKey;
        public RedmineReportsForm()
        {            

            try
            {
                InitializeComponent();
                installKey = Registry.CurrentUser.CreateSubKey(@"Software\" + Application.ProductName);
                if (installKey.GetValue("LastSelectedTrackers", null) == null)
                    installKey.SetValue("LastSelectedTrackers", string.Empty);

                dtpToDate.Text = DateTime.Now.ToShortDateString();
                dtpFromDate.Text = DateTime.Now.AddDays(-7).ToShortDateString();
                connString = ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            InitDataSource();
            try
            {
                _lL.DesignerWorkspace.Caption = "RedmineReports";
                _lL.Design(LlProject.List);
            }
            catch (ListLabelException)
            {
                
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void InitDataSource()
        {
            try
            {
                //read selected item                

                ListBox.SelectedIndexCollection TrackersListIndex = lstbTrackers.SelectedIndices;
                StringBuilder selectedTrackers = new StringBuilder();
                char[] chr = { ',' };
                if (TrackersListIndex.Count > 0)
                {
                    foreach (int index in TrackersListIndex)
                    {
                        DataRowView drItem = (DataRowView)lstbTrackers.Items[index];
                        selectedTrackers.Append( drItem["id"].ToString());
                        selectedTrackers.Append(",");
                    }

                }
                //.................
                //read selected item
                DataRowView drView = (DataRowView)lstbProjects.SelectedItem;
                string projectId = drView["id"].ToString();

                ListBox.SelectedIndexCollection listIndex = lboxVersion.SelectedIndices;
                StringBuilder sqlCommand = new StringBuilder();

                if (listIndex.Count > 0)
                {
                    int i = 0;
                    foreach (int index in listIndex)
                    {
                        DataRowView drItem = (DataRowView)lboxVersion.Items[index];
                        if (i == 0)
                            sqlCommand.Append(" AND (issues.fixed_version_id = " + drItem["id"].ToString());
                        else
                            sqlCommand.Append(" OR issues.fixed_version_id = " + drItem["id"].ToString());
                        i++;
                    }
                    sqlCommand.Append(")");
                }

                //get redmine project name
                _lL.Variables.Add("Redmine.ProjectName", _dataAccess.GetRedmineProjectName(projectId));

                // if more than one version is selected use "Multiple Versions"
                if (lboxVersion.SelectedIndices.Count == 1)
                {
                    DataRowView drItem = (DataRowView)lboxVersion.Items[lboxVersion.SelectedIndex];
                    _lL.Variables.Add("Redmine.VersionName", drItem["name"].ToString());
                }
                else if (lboxVersion.SelectedIndices.Count > 1)
                {
                    _lL.Variables.Add("Redmine.VersionName", "Multiple Versions");
                }
                else
                {
                    _lL.Variables.Add("Redmine.VersionName", String.Empty);
                }

                // get the redmine url
                _lL.Variables.Add("Redmine.HostName", _dataAccess.GetRedmineHostName());

                int startDate = Convert.ToInt32(numUpDoStartDate.Value);

                if (rbDateRange.Checked)
                    _lL.DataSource = _dataAccess.GetRedmineData(projectId, sqlCommand.ToString(), Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), selectedTrackers.ToString().TrimEnd(chr));
                else if (rbDays.Checked)
                    _lL.DataSource = _dataAccess.GetRedmineData(projectId, sqlCommand.ToString(), startDate, selectedTrackers.ToString().TrimEnd(chr));
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            catch (ListLabelException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 247);
            this.GetMainWindowsPos();
            try
            {
                if (RedmineReportsConfigDataHelper.ConnectionStringEncrypted(connString))
                {
                    _dataAccess = new RedmineMySqlDataAccess();
                }
                else
                {
                    if (RedmineReportsConfigDataHelper.ConnectionStringIsPlain(connString))
                    {
                        _dataAccess = new RedmineMySqlDataAccess(null, RedmineReportsConfigDataHelper.ConnectionStringIsPlain(connString));
                    }
                    else
                    {
                        //open config form for sql data
                        ConfigureMySqlDataBaseConnection();
                    }
                }

                _lL = new ListLabel();
                // Add your License Key
                _lL.LicensingInfo = "Insert license key here";

                // fill project listbox
                if (_dataAccess != null)
                    lstbProjects.DataSource = _dataAccess.GetRedmineProjects(Convert.ToBoolean(ConfigurationManager.AppSettings["UseAllProjects"]));
                lstbProjects.DisplayMember = "display_name";
                lstbProjects.ValueMember = "id";

                // check or uncheck checkbox for subprojects
                cbAllProjects.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["UseAllProjects"]);

                DesignerFunction fct = new DesignerFunction();
                fct.FunctionName = "GetStatusNameFromId";
                fct.GroupName = "RedmineFunctions";
                fct.ResultType = LlParamType.String;
                fct.MinimalParameters = 1;
                fct.MaximumParameters = 1;
                fct.Parameter1.Type = LlParamType.Double;
                fct.EvaluateFunction += new EvaluateFunctionHandler(fct_EvaluateFunction);
                _lL.DesignerFunctions.Add(fct);

                lstbTrackers.Enabled = !AllLstBoxItemsSelected(lstbTrackers);
                chkBox_All_Trackers.Checked = AllLstBoxItemsSelected(lstbTrackers);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTrackersList()
        {
            //get last selected items
            string LastSelectedTrackers = installKey.GetValue("LastSelectedTrackers").ToString();
            List<string> LastSelectedTrackersList = LastSelectedTrackers.Split(';').Select(item => item.Trim()).ToList<string>();

            if(lstbProjects.SelectedItem != null)
            {
                DataRowView drView = (DataRowView)lstbProjects.SelectedItem;
                string sProjectID = drView["id"].ToString();

                //get all related trackers to project and fill the listbox
                lstbTrackers.DataSource = _dataAccess.GetRedmineTrackers(sProjectID);
                lstbTrackers.DisplayMember = "display_name";
                lstbTrackers.ValueMember = "id";
                lstbTrackers.SelectedIndices.Clear();

                //set last selected items
                for (int i = 0; i < LastSelectedTrackersList.Count; i++)
                {
                    for (int j = 0; j < lstbTrackers.Items.Count; j++)
                    {
                        if(lstbTrackers.GetItemText(lstbTrackers.Items[j]).Contains(LastSelectedTrackersList[i].ToString()))
                        {
                            lstbTrackers.SetSelected(j, true);
                        }
                    }
                    
                }

            }
        }
        void fct_EvaluateFunction(object sender, EvaluateFunctionEventArgs e)
        {
            e.ResultValue = _dataAccess.GetStatusNameFromId(Int32.Parse(e.Parameter1.ToString()));
        }

        private void UpdateVersionBox()
        {
            //read selected item
            if (lstbProjects.SelectedItem != null)
            {
                DataRowView drView = (DataRowView)lstbProjects.SelectedItem;
                string sProjectID = drView["id"].ToString();

                // get all versions for the project and fill the listbox
                lboxVersion.DataSource = _dataAccess.GetVersions(sProjectID); ;
                lboxVersion.DisplayMember = "name";
                lboxVersion.ValueMember = "id";
                lboxVersion.SelectedIndices.Clear();
                lboxVersion.SelectedIndex = lboxVersion.Items.Count - 1;
            }
            else
            {
                lboxVersion.DataSource = null;
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersionBox();
            UpdateTrackersList();
        }

        private void lstbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersionBox();
            UpdateTrackersList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lL.Dispose();
            if (_dataAccess != null)
                _dataAccess.Dispose();

            this.SetWindowsPostion();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "Report.lst";
                if (!File.Exists(file))
                    file = ChooseFile();

                if (File.Exists(file))
                {
                    ExportConfiguration config = new ExportConfiguration(LlExportTarget.Pdf, Path.Combine(Path.GetTempPath(),"statistics.pdf"), file);
                    config.ShowResult = true;
                    config.BoxType = LlBoxType.NormalMeter;
                    InitDataSource();
                    _lL.Export(config);
                }
            }
            catch (ListLabelException)
            {                              
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string ChooseFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.Filter = "List & Label project file (*.lst)|*.lst";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                return fileDialog.FileName;
            throw new ListLabelException("The dialog was canceled by the user.");
        }

        private void cbAllProjects_CheckedChanged(object sender, EventArgs e)
        {
            if (_dataAccess != null)
                lstbProjects.DataSource = _dataAccess.GetRedmineProjects(cbAllProjects.Checked);
        }

        //private void tbFromDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((Keys)e.KeyChar) == Keys.Back || ((int)e.KeyChar) == 46)
        //        return;
        //    if (!Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
        //        e.Handled = true;
        //}

        //private void tbToDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((Keys)e.KeyChar) == Keys.Back || ((int)e.KeyChar) == 46)
        //        return;
        //    if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
        //        e.Handled = true;
        //}


        private void redmineDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RedmineMySqlConfig rmc = new RedmineMySqlConfig(this);
            rmc.ShowDialog();
        }

        public void reloadCmb(string ConnectionString)
        {
            //InitializeComponent();
            _dataAccess = null;
            _dataAccess = new RedmineMySqlDataAccess(ConnectionString);

            lstbProjects.DataSource = null;
            lstbProjects.DataSource = _dataAccess.GetRedmineProjects(Convert.ToBoolean(ConfigurationManager.AppSettings["UseAllProjects"]));
            lstbProjects.DisplayMember = "display_name";
            lstbProjects.ValueMember = "id";
        }

        private void ConfigureMySqlDataBaseConnection()
        {
            RedmineMySqlConfig rmc = new RedmineMySqlConfig(this);
            rmc.ShowDialog();
            if (rmc.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                Environment.Exit(-1);
        }

        List<string> strItemList = new List<string>();
        private void RedmineReportsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //write last selected tracker to registry
            string strItems;
            string strItem;
            if(lstbTrackers.SelectedItems.Count !=0)
            { 
                foreach (DataRowView selecteditem in lstbTrackers.SelectedItems)
                {
                    strItem = selecteditem["name"].ToString();
                    if (!strItemList.Contains(strItem))
                        strItemList.Add(strItem);
                    strItems = String.Join(";", strItemList.ToArray());
                    installKey.SetValue("LastSelectedTrackers", strItems);
                }
            }
            else
            {
                DataRowView item = (DataRowView)lstbTrackers.Items[lstbTrackers.Items.Count - 1];
                strItem = item["name"].ToString();
                installKey.SetValue("LastSelectedTrackers", strItem);
                lstbTrackers.SelectedIndex = lstbTrackers.Items.Count - 1;

            }

        }

        private void chkBox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < lboxVersion.Items.Count; i++)
            {
                lboxVersion.SetSelected(i, chkBox_SelectAll.Checked);
            }

            lboxVersion.Enabled = chkBox_SelectAll.Checked ? false : true;
        }

        private void chkBox_All_Trackers_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstbTrackers .Items.Count; i++)
            {
                lstbTrackers.SetSelected(i, chkBox_All_Trackers.Checked);
            }

            lstbTrackers.Enabled = chkBox_All_Trackers.Checked ? false : true;
            
        }

        private void rbDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDays.Checked)
            {                
                numUpDoStartDate.Enabled = true;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else if (rbDateRange.Checked)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                numUpDoStartDate.Enabled = false;
            }

        }

        private bool AllLstBoxItemsSelected(ListBox lstBox)
        {            
            return lstBox.SelectedItems.Count == lstBox.Items.Count;
        }

        private bool NothingCheckd(ListBox lstBox1, ListBox lstBox2)
        {
            return lstBox1.SelectedItems.Count < 1 || lstBox2.SelectedItems.Count < 1;
        }

    }
    public static class ExtensionsMethod
    {
        private static RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\" + Application.ProductName);

        public static void SetWindowsPostion(this Form frm)
        {
            installKey.SetValue("LocationX", frm.DesktopLocation.X);
            installKey.SetValue("LocationY", frm.DesktopLocation.Y);
        }

        public static void GetMainWindowsPos(this Form frm)
        {
            if (installKey == null)
                Registry.CurrentUser.CreateSubKey(@"Software\" + Application.ProductName);

            frm.Location = new System.Drawing.Point(System.Convert.ToInt32(installKey.GetValue("LocationX")),
                System.Convert.ToInt32(installKey.GetValue("LocationY")));

            if (!Screen.GetWorkingArea(frm).Contains(frm.Bounds))
            {
                frm.SetDesktopLocation(0, 0);
            }

        }


    }
}