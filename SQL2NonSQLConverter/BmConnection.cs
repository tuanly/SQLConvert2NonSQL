using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Runtime;



namespace SQL2NonSQLConverter
{
    class BmConnection
    {
        private static SqlConnection mSQLServerCnn;
        private const string SQLDBName = "bmdb";
        private static IMongoClient mMongoClient = null;

        public static bool Connect2SQLServer(string stServer, string stUsername, string stPwd)
        {
            bool result = true;
            try
            {
                string source = @"user id=" + stUsername + ";" +
                                       "password=" + stPwd + ";server=" + stServer + ";" +
                                       "Trusted_Connection=yes;" +
                                       "database=" + SQLDBName + "; " +
                                       "connection timeout=30";
                mSQLServerCnn = new SqlConnection(source);
                mSQLServerCnn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                result = false;
            }
            return result;
        }

        public static void CloseSQLServerConnection()
        {
            if (mSQLServerCnn != null && mSQLServerCnn.State != System.Data.ConnectionState.Closed)
                mSQLServerCnn.Close();
        }

        public static bool Connect2MongoDB()
        {
            string source = "mongodb://127.0.0.1:27017";
            mMongoClient = new MongoClient(source);
            return true;
        }


      
    }
}
