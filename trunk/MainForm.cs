using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using combit.ListLabel17;
using System.IO;
using System.Configuration;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Xml;


namespace combit.RedmineReports
{
    public partial class RedmineReportsForm : Form
    {
        ListLabel LL;
        RedmineMySqlDataAccess _dataAccess;
        public RedmineReportsForm()
        {
            InitializeComponent();
            if (ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString.Contains("server=IP"))
            {
                MessageBox.Show("Please edit your 'RedmineReports.exe.config' in the \\bin folder and add a ConnectionString to your redmine database.\n If you want to print all projects use 'UseAllProjects = True' otherwise use 'UseAllProjects = False'", "Redmine Reports");
                Environment.Exit(-1);
            }   
            _dataAccess = new RedmineMySqlDataAccess();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {

            InitDataSource();
            try
            {
                LL.Design(LlProject.List, "Report.lst");
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
                string sqlCommand = "";
                
                if (listIndex.Count > 0)
                {    
                    int i = 0;
                    foreach (int index in listIndex)
                    {
                        DataRowView drItem = (DataRowView)lboxVersion.Items[index];
                        if (i == 0)
                            sqlCommand += " AND (issues.fixed_version_id = " + drItem["id"].ToString();
                        else
                            sqlCommand += " OR issues.fixed_version_id = " + drItem["id"].ToString();
                        i++;
                    }
                    sqlCommand += ")";
                }

                //get redmine project name
                LL.Variables.Add("Redmine.ProjectName", _dataAccess.GetRedmineProjectName(projectId));

                // if more than one version is selected use "Multiple Versions"
                if (lboxVersion.SelectedIndices.Count == 1)
                {
                    DataRowView drItem = (DataRowView)lboxVersion.Items[lboxVersion.SelectedIndex];
                    LL.Variables.Add("Redmine.VersionName", drItem["name"].ToString());
                }
                else if (lboxVersion.SelectedIndices.Count > 1)
                {
                    LL.Variables.Add("Redmine.VersionName", "Multiple Versions");
                }
                else
                {
                    LL.Variables.Add("Redmine.VersionName", String.Empty);
                }

                // get the redmine url
                LL.Variables.Add("Redmine.HostName", _dataAccess.GetRedmineHostName());

                int startDate = Convert.ToInt32(tbStartDate.Text.ToString());

                LL.DataSource = _dataAccess.GetRedmineData(projectId, sqlCommand, startDate);
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
                LL = new ListLabel();
                // Add your License Key
                LL.LicensingInfo = "Insert license key here";

                // fill project combobox
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
                LL.DesignerFunctions.Add(fct);

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
            DataRowView drView = (DataRowView)cmbProject.SelectedItem;
            string sProjectID = drView["id"].ToString();

            // get all versions for the project and fill the listbox
            lboxVersion.DataSource = _dataAccess.GetVersions(sProjectID); ;
            lboxVersion.DisplayMember = "name";
            lboxVersion.ValueMember = "id";
            lboxVersion.SelectedIndices.Clear();
            lboxVersion.SelectedIndex = lboxVersion.Items.Count - 1;
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersionBox();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LL.Dispose();
            _dataAccess.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "Report.lst";
                if (!File.Exists(file))
                    file = ChooseFile();
                if (File.Exists(file))
                {
                    ExportConfiguration config = new ExportConfiguration(LlExportTarget.Pdf, Path.GetTempPath() + @"\statistics.pdf", file);
                    config.ShowResult = true;
                    config.BoxType = LlBoxType.NormalMeter;
                    InitDataSource();
                    LL.Export(config);
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

            if(source.TextLength == 1)
            {
                source.ResetText();
            }
            else
            {
                source.ResetText();
                source.AppendText(text.Substring(0, text.Length - 1));
            }
            source.TextChanged += this.tbStartDate_TextChanged;
        }

        private void cbAllProjects_CheckedChanged(object sender, EventArgs e)
        {
            cmbProject.DataSource = _dataAccess.GetRedmineProjects(cbAllProjects.Checked);
        }
    }
}
