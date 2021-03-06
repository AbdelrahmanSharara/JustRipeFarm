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
        public static bool Verified { get => verify; }
        private static bool verify = false;
        public static string usernull2;
        public static string usernull;
        public static string permnull;


        /// <summary>
        /// This method checks the username & password if they match the database
        /// the CharArray is used to check the database for apostrophe or Sql injection
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public static bool VerifyLogin(string username, string password)
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            DataSet dataSet = new DataSet();

            usernull = username;
            usernull2 = username;
            permnull = username;


            // check for apostrophe and ignore it as false if mentioned
            char[] checkuser = username.ToCharArray();
            char[] checkpass = password.ToCharArray();

            for (int i = 0; i < checkuser.Length; i++)
            {
                if (checkuser[i] == '\'')
                {
                    return false;
                }
            }

            for (int i = 0; i < checkpass.Length; i++)
            {
                if (checkpass[i] == '\'')
                {
                    return false;
                }
            }

            string sqlStatement = ("SELECT * FROM LoginDB WHERE username = '" + username + "' AND password= '" + password + "'");


            dataSet = DBAcc.getDataSet(sqlStatement);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                verify = true;
            }

            else
            { verify = false; }
            return verify;
        }

        
        // used to display username on the top
        public static string displayuser()
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DataSet dataSet = new DataSet();
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            string sqlStatement = ("SELECT firstname, surname FROM LoginDB WHERE username='" + usernull + "'");
            dataSet =  DBAcc.getDataSet(sqlStatement);
            return "Hello" +' '+ dataSet.Tables[0].Rows[0][0].ToString() + ' ' + dataSet.Tables[0].Rows[0][1].ToString();
        }


        // Template got from Abdelrahman
        // Changed the SQL Statement and the return
        // Used to put in function permission for Crops Event
        public static string displayRole()
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DataSet dataSet = new DataSet();
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            string sqlStatement = ("SELECT permissions FROM LoginDB WHERE username='" + usernull2 + "'");
            dataSet = DBAcc.getDataSet(sqlStatement);
            return dataSet.Tables[0].Rows[0][0].ToString(); ;
        }

        //check permissions for the whole window
        public static string permcheck()
        {
            string connectionString = Properties.Settings.Default.DBAccess;
            DatabaseTransmission DBAcc = new DatabaseTransmission(connectionString);
            DataSet dataSet = new DataSet();


            string sqlStatementperm = ("SELECT permissions FROM LoginDB WHERE username = '" + permnull + "'");

            dataSet = DBAcc.getDataSet(sqlStatementperm);

            return dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }


}
