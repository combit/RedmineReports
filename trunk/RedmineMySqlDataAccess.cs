using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;


namespace combit.RedmineReports
{
    sealed class RedmineMySqlDataAccess : RedmineDataAccessBase
    {
        public RedmineMySqlDataAccess()
        {
            // create connection
            _connection = new MySqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["combit.RedmineReports.Properties.Settings.RedmineConnectionString"].ConnectionString;
            try
            {
                _connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override DataTable GetDataTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();                
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(sql, _connection as MySqlConnection);

                myAdapter.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

    }
}