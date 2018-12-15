using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRIpe
{
    class DatabaseTransmission
    {
        /// <summary>
        /// The DataTransmission class is used to connect the database
        /// to the program using  the connection string in the app settings
        /// written by : written by author : Abdelrahman Ahmed
        /// </summary>
        private string ConnectionStr;
        SqlConnection connectionToDB;
        private SqlDataAdapter  dataAdapter;


        public DatabaseTransmission(string connectionStr)
        { ConnectionStr = connectionStr; }

        public static string connectionstr
        {
            set { connectionstr = value; }
        }

        public void openConnection()
        {
            connectionToDB = new
            SqlConnection(ConnectionStr);
            connectionToDB.Open();

        }
        public void closeConnection()
        { connectionToDB.Close(); }

        public DataSet getDataSet(string sqlStatement)
        {
            openConnection();
            DataSet dataSet;
            
            dataAdapter = new SqlDataAdapter(sqlStatement, connectionToDB);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            closeConnection();
            return dataSet;
            
        }




    }
}

