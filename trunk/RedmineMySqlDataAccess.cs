using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;


namespace combit.RedmineReports
{
    sealed class RedmineMySqlDataAccess : RedmineDataAccessBase
    {
        public RedmineMySqlDataAccess() : this(null) { }
        public RedmineMySqlDataAccess(string ConnectionString, bool isPlain)
        {
            // create connection
            _connection = new MySqlConnection();
            if (ConnectionString == null)
            {
                _connection.ConnectionString = ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString;
            }
            else
            {
                _connection.ConnectionString = ConnectionString;
            }

            try
            {
                _connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public RedmineMySqlDataAccess(string ConnectionString)
        {
            // create connection
            _connection = new MySqlConnection();
            if (String.IsNullOrEmpty(ConnectionString))
            {
                string convertString = ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString;
                //decrypt connectionstring
                _connection.ConnectionString = RedmineReportsConfigDataHelper.DecryptData(convertString);
            }
            else
            {
                _connection.ConnectionString = ConnectionString;
            }
            
            try
            {
                _connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override string GetParameterFormat()
        {
            return "@{0}";
        }

        public override DataTable GetDataTable(string sql, IDbDataParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand command = new MySqlCommand(sql, _connection as MySqlConnection);

                if (parameters != null)
                {
                    foreach (IDbDataParameter parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }
                }
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = command;
                myAdapter.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Command was: " + sql);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public override IDbDataParameter GetParameter()
        {
            return _connection.CreateCommand().CreateParameter();
        }

    }
}