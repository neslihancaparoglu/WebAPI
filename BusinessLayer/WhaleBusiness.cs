using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLayer
{

    public class WhaleBusiness
    {
        public List<WhaleData> GetData()
        {
            List<WhaleData> whale = new List<WhaleData>();
            DataConnection dbConnection = new DataConnection();
            SqlConnection sqlConnection = dbConnection.OpenConnection();
            string query = "SELECT * FROM FarmofWhale";
            SqlCommand command = dbConnection.CreateCommand(query);
            SqlDataReader read = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (read.Read())
            {
                WhaleData whales = new WhaleData(
                    (int)read["WhaleId"],
                    read["Name"].ToString(),
                    (int)read["Age"],
                    read["Colour"].ToString(),
                    (bool)read["IsItPregnant"]

                    );
                whale.Add(whales);

            }
            return whale;
        }
        public void AddData(WhaleData data)
        {
            DataConnection dbConnection = new DataConnection();
            SqlConnection sqlConnection = dbConnection.OpenConnection();
            string query = "INSERT INTO FarmofWhale (Name,Age,Colour,IsItPregnant) VALUES (@Name,@Age,@Colour,@IsItPregnant)";
            SqlCommand command = dbConnection.CreateCommand(query);
            command.Parameters.AddWithValue("@Name", data.Name);
            command.Parameters.AddWithValue("@Age", data.Age);
            command.Parameters.AddWithValue("@Colour", data.Colour);
            command.Parameters.AddWithValue("@IsItPregnant", data.IsItPregnant);
            command.ExecuteNonQuery();
        }
        public int DeleteData(int id)
        {
            DataConnection dbConection = new DataConnection();
            SqlConnection sqlConnection = dbConection.OpenConnection();
            string query = "DELETE FROM FarmofWhale WHERE WhaleId=@WhaleId";
            SqlCommand command = dbConection.CreateCommand(query);
            command.Parameters.AddWithValue("@WhaleId", id);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
        public int UpDateData(int id, WhaleData whale)
        {
            DataConnection dbConection = new DataConnection();
            SqlConnection sqlConnection= dbConection.OpenConnection();
            string query = "UPDATE FarmofWhale SET Name=@Name,Age=@Age,Colour=@Colour,IsItPregnant=@IsItPregnant WHERE WhaleId=@WhaleId";
            SqlCommand command= dbConection.CreateCommand(query);
            command.Parameters.AddWithValue("@WhaleId", id);
            command.Parameters.AddWithValue("@Name", whale.Name);
            command.Parameters.AddWithValue("@Age", whale.Age);
            command.Parameters.AddWithValue("@Colour", whale.Colour);
            command.Parameters.AddWithValue("@IsItPregnant", whale.IsItPregnant);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
        

    }
    

}
