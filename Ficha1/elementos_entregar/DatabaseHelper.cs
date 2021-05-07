using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class DatabaseHelper
    {
        public static int CreateStudent(string name, string ucName)
        {
            SqlConnection sqlConnection = null;
            try
            {
                var connectionString = Properties.Settings.Default.Worksheet1DatabaseConnectionString;

                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO StudentTable (StudentName, UCName) VALUES (@name, @ucName)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@ucName", ucName);
                sqlConnection.Open();

                int rowsAffected = (int)cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
    }
}
