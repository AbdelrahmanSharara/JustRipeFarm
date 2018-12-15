using System;
using System.Data;

namespace JustRIpe.DB
{
    class DatabaseStatements
    {
       




        public static DataSet displayEmployees(string sqlStatement)
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DataSet dataSet = new DataSet();
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            
            dataSet = DBAcc.getDataSet(sqlStatement);

            return dataSet;
        }



        public static DataSet GetUsers(string sqlStatement)
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DataSet dataSet = new DataSet();

            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            dataSet = DBAcc.getDataSet(sqlStatement);

            return dataSet;
        }
    }
}
