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
        private SqlConnection mSQLServerCnn;

        private MongoClient mMongoClient = null;
        private MongoServer mMongoServer = null;
        private MongoDatabase mMongoDB = null;


        public SqlConnection sqlCNN
        {
            get
            {
                return mSQLServerCnn;
            }
            set 
            {
                 mSQLServerCnn = value; 
            }
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

        public void CloseSQLServerConnection()
        {
            //if (mSQLServerCnn != null && mSQLServerCnn.State != System.Data.ConnectionState.Closed)
            //    mSQLServerCnn.Close();
        }

        public bool Connect2MongoDB()
        {
            string source = "mongodb://127.0.0.1:27017";
            mMongoClient = new MongoClient();
            mMongoServer = mMongoClient.GetServer();
            mMongoDB = mMongoServer.GetDatabase("MyDatabase");
            return true;
        }


      
    }
}
