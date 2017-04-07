using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Runtime;



namespace SQL2NonSQLConverter
{
    public class BmConnection
    {
        private SqlConnection mSQLServerCnn;


    
        private MongoClient mMongoClient = null;
        public SqlConnection SQLServerCnn
        {
            get { return mSQLServerCnn; }
            set { mSQLServerCnn = value; }
        }
        
        public bool Connect2SQLServer(string stServer, string stDbName, string stUsername, string stPwd)
        {
            bool result = true;
            try
            {
                string source = @"user id=" + stUsername + ";" +
                                       "password=" + stPwd + ";server=" + stServer + ";" +
                                       "Trusted_Connection=yes;" +
                                       "database=" + stDbName + "; " +
                                       "connection timeout=30";
                SQLServerCnn = new SqlConnection(source);
                SQLServerCnn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                result = false;
            }
            return result;
        }

        public void CloseSQLServerConnection()
        {
            //if (mSQLServerCnn != null && mSQLServerCnn.State != System.Data.ConnectionState.Closed)
            //    mSQLServerCnn.Close();
        }

        public bool Connect2MongoDB()
        {
            string source = "mongodb://127.0.0.1:27017";
            mMongoClient = new MongoClient(source);
            
            return true;
        }

        public static SqlConnection getSQLConnection()
        {
            return SQLServerCnn;
        }

    }
}
