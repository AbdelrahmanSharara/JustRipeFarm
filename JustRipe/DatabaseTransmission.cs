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
        private string ConnectionStr;
        SqlConnection connectionToDB;
        private SqlDataAdapter  dataAdapter;


        public DatabaseTransmission(string connectionStr)
        { this.ConnectionStr = connectionStr; }

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
            DataSet dataSet;
            dataAdapter = new SqlDataAdapter(sqlStatement, connectionToDB);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }




    }
}

