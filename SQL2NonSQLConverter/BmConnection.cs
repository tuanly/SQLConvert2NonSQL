using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Runtime;
using System.Reflection;

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
        public MongoDatabase nonSQLCNN
        {
            get
            {
                return mMongoDB;
            }
            set
            {
                mMongoDB = value;
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

        public bool Connect2MongoDB(string ip, string port, string dbName)
        {
            string source = "mongodb://" + ip + ":" + " :" + port;
           

            try
            {
                mMongoClient = new MongoClient();
                mMongoServer = mMongoClient.GetServer();
                mMongoDB = mMongoServer.GetDatabase(dbName);
                mMongoDB.Drop();
               // mMongoDB.CreateCollection(dbName);
            }
            catch(Exception ex)
            {
                return false;
            }
            //BmClassBuilder MCB = new BmClassBuilder("BookStore");
            //var myclass = MCB.CreateObject(new string[5] { "Id", "BookTitle", "Auther", "Category", "ISBN" }, new Type[5] { typeof(ObjectId), typeof(string), typeof(string), typeof(string), typeof(string) });
            //var myObject = Activator.CreateInstance(myclass.GetType());

            //myclass.GetType().GetProperty("BookTitle", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "dddMongoDB Basics", null);
            //myclass.GetType().GetProperty("ISBN", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "8767687689898yu", null);
            //myclass.GetType().GetProperty("Auther", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "Tanya", null);
            //myclass.GetType().GetProperty("Category", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "NoSQL DBMS", null);
            //var collection = mMongoDB.GetCollection("BookStore");


            //    collection.Save(myObject);

      
            
            return true;
        }


      
    }
    
}
