﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace JustRIpe
{
    class LoginAuth
    {
        private static bool verified = false;

        public static bool Verified { get => verified; }

        

        public static bool VerifyLogin(string username, string password)
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            DataSet dataSet = new DataSet();

            DBAcc.openConnection();


            string sqlStatement = ("SELECT * FROM LoginDB WHERE username = '" + username + "' AND password= '" + password + "'");


            dataSet = DBAcc.getDataSet(sqlStatement);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                verified = true;

            }

            else
            { verified = false; }

            DBAcc.closeConnection();

            return Verified;


        }

        public static string CheckPerm(string username)
        { string connectionString = Properties.Settings.Default.DBAccess;
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            DataSet dataSet = new DataSet();
            DBAcc.openConnection();

            string sqlStatementperm = ("SELECT permissions FROM LoginDB WHERE username = '" + username + "'");

            dataSet = DBAcc.getDataSet(sqlStatementperm);
            DBAcc.closeConnection();
            return dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }


}