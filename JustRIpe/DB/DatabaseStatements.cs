using System;
using System.Data;

namespace JustRIpe.DB
{
    class DatabaseStatements
    {
        public static string usergrid;




        public static DataSet displayusergrid()
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DataSet dataSet = new DataSet();
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            string usersql = ("SELECT name, email, phone FROM Users WHERE role='" + usergrid + "'");
            dataSet = DBAcc.getDataSet(usersql);

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
