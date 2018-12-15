using System;
using System.Data;

namespace JustRIpe.DB
{
    class DatabaseStatements
    {
       


        /// <summary>
        /// The following statement is used
        /// </summary>
        /// <param name="sqlStatement"></param>
        /// <returns></returns>

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
