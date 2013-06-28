using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace combit.RedmineReports
{
    public partial class RedmineMySqlConfig : Form
    {
        private RedmineReportsForm redmineReportsForm;

        public RedmineMySqlConfig(RedmineReportsForm redmineReportsForm)
        {
            this.redmineReportsForm = redmineReportsForm;
            InitializeComponent();
            CompleteBoxes();
        }

        private void CompleteBoxes()
        {
            ConfigurationManager.RefreshSection("combit.RedmineReports.Properties.Settings.RedmineConnectionString");
            string convertString = ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString;
            if(RedmineReportsConfigDataHelper.ConnectionStringEncrypted(convertString))
            {
                //decrypt connectionstring
                convertString =RedmineReportsConfigDataHelper.DecryptData(convertString);
            }

            Match m = Regex.Match(convertString, "server=([^;]*);uid=([^;]*);pwd=([^;]*);database=([^;]*)");
            ipAddressTextBox.Text = m.Groups[1].Value;
            mySQLLogTextBox.Text = m.Groups[2].Value;
            mySQLPasssTextBox.Text = m.Groups[3].Value;
            dbNameTextBox.Text = m.Groups[4].Value;
        }

        private void checkConfButton_Click(object sender, EventArgs e)
        {
            if (checkConfButton.Text.Equals("Check config"))
            {
                checkConfButton.Text = "Stop";
                pictureBox1.Visible = true;
                var args = Tuple.Create<string, string, string, string, bool>
                    (ipAddressTextBox.Text, mySQLLogTextBox.Text, mySQLPasssTextBox.Text,
                    dbNameTextBox.Text, encryptData.Checked);
                backgroundWorker1.RunWorkerAsync(args);
              
            }
            else
            {
                this.backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<string, string, string, string, bool> args = e.Argument as Tuple<string, string, string, string, bool>;
            // create connection
            IDbConnection _connection = new MySqlConnection();
            _connection.ConnectionString = string.Format("server={0};uid={1};pwd={2};database={3}",
                args.Item1, args.Item2, args.Item3, args.Item4);
            try
            {
                _connection.Open();
                _connection.Close();
                _connection = null;

                MessageBox.Show("Connection succeeded.", "Test connection", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
        }

        // This event handler deals with the results of the 
        // background operation. 
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
                saveButton.Enabled = true;
            }
            checkConfButton.Text = "Check config";
            pictureBox1.Visible = false;
        }

        private void DisableSaveButton(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration("RedmineReports.exe");
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            string convertString = connectionStringsSection.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString =
                string.Format("server={0};uid={1};pwd={2};database={3}",
                    ipAddressTextBox.Text, mySQLLogTextBox.Text, mySQLPasssTextBox.Text,
                    dbNameTextBox.Text);
            if (encryptData.Checked)
            {
               //encrpyt connectionstring
                connectionStringsSection.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString = RedmineReportsConfigDataHelper.EncryptData(convertString);
            }
            else
            {
                connectionStringsSection.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString = convertString;
            }

            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            saveButton.Enabled = false;
            redmineReportsForm.reloadCmb(string.Format("server={0};uid={1};pwd={2};database={3}",
                    ipAddressTextBox.Text, mySQLLogTextBox.Text, mySQLPasssTextBox.Text,
                    dbNameTextBox.Text));

            Close();
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}
