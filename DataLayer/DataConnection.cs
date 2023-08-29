using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class DataConnection
    {
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-QOA708NL\\SQLEXPRESS;Initial Catalog=FarmOfWhale;Integrated Security=True");
            connection.Open();
            return connection;
        }
        public SqlCommand CreateCommand(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, OpenConnection());
            return sqlCommand;
        }

    }
}
