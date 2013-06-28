using combit.ListLabel18;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace combit.RedmineReports
{
    public partial class RedmineReportsForm : Form
    {
        ListLabel _lL;
        string connString;
        RedmineMySqlDataAccess _dataAccess;
        public RedmineReportsForm()
        {
            try
            {
                InitializeComponent();

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
                _lL.Design(LlProject.List, "Report.lst");
            }
            catch (ListLabelException ex)
            {
                MessageBox.Show(ex.Message);
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
                DataRowView drView = (DataRowView)cmbProject.SelectedItem;
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

                int startDate = Convert.ToInt32(tbStartDate.Text.ToString());

                if (rbDateRange.Checked)
                    _lL.DataSource = _dataAccess.GetRedmineData(projectId, sqlCommand.ToString(), Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text));
                else if (rbTimespan.Checked)
                    _lL.DataSource = _dataAccess.GetRedmineData(projectId, sqlCommand.ToString(), startDate);
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

                // fill project combobox
                if (_dataAccess != null)
                    cmbProject.DataSource = _dataAccess.GetRedmineProjects(Convert.ToBoolean(ConfigurationManager.AppSettings["UseAllProjects"]));

                cmbProject.DisplayMember = "display_name";
                cmbProject.ValueMember = "id";

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

        void fct_EvaluateFunction(object sender, EvaluateFunctionEventArgs e)
        {
            e.ResultValue = _dataAccess.GetStatusNameFromId(Int32.Parse(e.Parameter1.ToString()));
        }

        private void UpdateVersionBox()
        {
            //read selected item
            if (cmbProject.SelectedItem != null)
            {
                DataRowView drView = (DataRowView)cmbProject.SelectedItem;
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lL.Dispose();
            if (_dataAccess != null)
                _dataAccess.Dispose();
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
            catch (ListLabelException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void tbStartDate_TextChanged(object sender, EventArgs e)
        {
            TextBox source = sender as TextBox;
            if (source == null)
                return;

            string text = source.Text;
            if (Regex.IsMatch(text, "^[0-9]*$"))
                return;

            source.TextChanged -= this.tbStartDate_TextChanged;

            source.ResetText();
            if (source.TextLength != 1)
            {
                source.AppendText(text.Substring(0, text.Length - 1));
            }
            
            source.TextChanged += this.tbStartDate_TextChanged;
        }

        private void cbAllProjects_CheckedChanged(object sender, EventArgs e)
        {
            if (_dataAccess != null)
                cmbProject.DataSource = _dataAccess.GetRedmineProjects(cbAllProjects.Checked);
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

        private void rbTimespan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTimespan.Checked)
            {
                tbStartDate.Enabled = true;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else if (rbDateRange.Checked)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                tbStartDate.Enabled = false;
            }
        }

        private void redmineDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RedmineMySqlConfig rmc = new RedmineMySqlConfig(this);
            rmc.Show();
        }

        public void reloadCmb(string ConnectionString)
        {
            //InitializeComponent();
            _dataAccess = null;
            _dataAccess = new RedmineMySqlDataAccess(ConnectionString);
            cmbProject.DataSource = null;
            cmbProject.DataSource = _dataAccess.GetRedmineProjects(Convert.ToBoolean(ConfigurationManager.AppSettings["UseAllProjects"]));
            cmbProject.DisplayMember = "display_name";
            cmbProject.ValueMember = "id";
        }

        private void ConfigureMySqlDataBaseConnection()
        {
            RedmineMySqlConfig rmc = new RedmineMySqlConfig(this);
            rmc.ShowDialog();
        }
    }
}