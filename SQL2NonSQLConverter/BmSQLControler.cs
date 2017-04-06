using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2NonSQLConverter
{
    class BmSQLControler
    {
        private string m_stServerName;
        private string m_stUserName;
        private string m_stUserPW;
        private BmConnection m_sqlCnn = null;
        private BmSQLDatabaseDataType m_sqlSchema = null;

        public BmSQLControler()
        {
            StServerName = "";
            StUserName = "";
            StUserPW = "";
            m_sqlCnn = new BmConnection();
            SqlSchema = new BmSQLDatabaseDataType();
        }

        public BmSQLControler(string stServerName, string stUserName, string stPassword)
        {
            m_stServerName = stServerName;
            m_stUserName = stUserName;
            m_stUserPW = stPassword;
            m_sqlCnn = new BmConnection();
            SqlSchema = new BmSQLDatabaseDataType();
        }
        
        public string StServerName { get => m_stServerName; set => m_stServerName = value; }
        public string StUserName { get => m_stUserName; set => m_stUserName = value; }
        public string StUserPW { get => m_stUserPW; set => m_stUserPW = value; }
        internal BmSQLDatabaseDataType SqlSchema { get => m_sqlSchema; set => m_sqlSchema = value; }

        ~BmSQLControler()
        {
            if (m_sqlCnn != null)
                m_sqlCnn.CloseSQLServerConnection();
            m_sqlCnn = null;
        }

        public void sqlInit()
        {
            m_sqlCnn.Connect2SQLServer(m_stServerName, m_stUserName, m_stUserPW);
            getSQLSchema();
        }

        private BmSQLDatabaseDataType getSQLSchema()
        {
            SqlSchema = new BmSQLDatabaseDataType();
            DataTable tables = m_sqlCnn.sqlCNN.GetSchema("Tables");
            DisplayData(tables);
            return SqlSchema;
        }

        private void DisplayData(System.Data.DataTable table)
        {
            foreach (System.Data.DataRow row in table.Rows)
            {
                BmSQLTableDataType sqlTable = null;
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    
                    if (col.ColumnName.Equals("TABLE_NAME"))
                    {
                        Debug.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                        sqlTable = new BmSQLTableDataType();
                        sqlTable.StTableName = row[col].ToString();
                        DataTable fields = m_sqlCnn.sqlCNN.GetSchema(SqlClientMetaDataCollectionNames.Columns, new string[] { null, null, sqlTable.StTableName });
                        foreach (DataRow dr in fields.Rows)
                        {
                            BmSQLColumnDataType sqlColumn = new BmSQLColumnDataType();
                            sqlColumn.ColName = dr["COLUMN_NAME"].ToString();
                            Debug.WriteLine(sqlColumn.ColName);
                            //get column type
                            string sql = "SELECT + ["  + sqlColumn.ColName + "] FROM [" + sqlTable.StTableName+ "]";
                            SqlCommand sqlCMD = new SqlCommand(sql, m_sqlCnn.sqlCNN);
                            SqlDataReader sqlReader = sqlCMD.ExecuteReader(CommandBehavior.KeyInfo);
                            DataTable schemaDataType = sqlReader.GetSchemaTable();
                            foreach (DataRow type in schemaDataType.Rows)
                            {
                                foreach (DataColumn property in schemaDataType.Columns)
                                {
                                    Debug.WriteLine(property.ColumnName + " : " + type[property].ToString());
                                    if (property.ColumnName.Equals("DataTypeName"))
                                    {
                                        sqlColumn.updateDataType(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("NumericPrecision"))
                                    {
                                        sqlColumn.NumericPrecision = Int16.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("NumericScale"))
                                    {
                                        sqlColumn.NumericScale = Int16.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("IsUnique"))
                                    {
                                        sqlColumn.IsUnique = Boolean.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("IsKey"))
                                    {
                                        sqlColumn.IsKey = Boolean.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("IsIdentity"))
                                    {
                                        sqlColumn.IsIdentity = Boolean.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("IsAutoIncrement"))
                                    {
                                        sqlColumn.IsAutoIncrement = Boolean.Parse(type[property].ToString());
                                    }
                                    else if (property.ColumnName.Equals("IsReadOnly"))
                                    {
                                        sqlColumn.IsReadOnly = Boolean.Parse(type[property].ToString());
                                    }
                                    
                                }
                            }
                            sqlTable.Columns.Add(sqlColumn);
                            sqlReader.Close();
                        }
                    }
                }
                if (sqlTable != null)
                    SqlSchema.Tables.Add(sqlTable);
                Debug.WriteLine("============================");
            }
        }
    }

}
