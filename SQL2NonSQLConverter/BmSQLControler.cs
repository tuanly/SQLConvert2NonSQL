﻿
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
        private string m_stDBName;
        private string m_stUserName;
        private string m_stUserPW;
       
        private BmConnection m_sqlCnn = null;
        private BmSQLDatabaseDataType m_sqlSchema = null;

        

        public BmSQLControler()
        {
            m_stServerName = "";
            m_stUserName = "";
            m_stUserPW = "";
            m_stDBName = "";
            m_sqlCnn = new BmConnection();
            m_sqlSchema = new BmSQLDatabaseDataType();
        }

        public BmSQLControler(string stServerName, string stDbName, string stUserName, string stPassword)
        {
            m_stServerName = stServerName;
            m_stUserName = stUserName;
            m_stUserPW = stPassword;
            m_stDBName = stDbName;
            m_sqlCnn = new BmConnection();
            m_sqlSchema = new BmSQLDatabaseDataType();
        }
        
        public string DBName
        {
          get { return m_stDBName; }
          set { m_stDBName = value; }
        }
        public string ServerName
        {
          get { return m_stServerName; }
          set { m_stServerName = value; }
        }
        

        public string UserPW
        {
          get { return m_stUserPW; }
          set { m_stUserPW = value; }
        }

        internal BmSQLDatabaseDataType SqlSchema
        {
            get { return m_sqlSchema; }
            set { m_sqlSchema = value; }
        }
        ~BmSQLControler()
        {
            if (m_sqlCnn != null)
                m_sqlCnn.CloseSQLServerConnection();
            m_sqlCnn = null;
        }

        public void sqlInit()
        {
            m_sqlCnn.Connect2SQLServer(m_stServerName, m_stDBName, m_stUserName, m_stUserPW);
            getSQLSchema();
        }

        private BmSQLDatabaseDataType getSQLSchema()
        {
            SqlSchema = new BmSQLDatabaseDataType();
            DataTable tables = m_sqlCnn.sqlCNN.GetSchema("Tables");
            getSchema(tables);            
            return SqlSchema;
        }

        private List<BmSQLDataRow> getData(BmSQLTableDataType table)
        {
            List<BmSQLDataRow> lsData = new List<BmSQLDataRow>();
            SqlDataReader sqlReader = null;
            try
            {
                string sql = "SELECT ";
                for(int i = 0; i < table.Columns.Count; i++)
                {
                    sql += " " + table.Columns[i].ColName +  " ";
                    if (i < table.Columns.Count - 1) sql += " , ";
                    
                }

                sql += " FROM[" + table.TableName + "]";
                SqlCommand sqlCMD = new SqlCommand(sql, m_sqlCnn.sqlCNN);
                sqlReader = sqlCMD.ExecuteReader(CommandBehavior.Default);                
                while (sqlReader.Read())
                {
                    BmSQLDataRow row = new BmSQLDataRow();
                    for (int i = 0; i < sqlReader.FieldCount; i++)
                    {
                        row.ColValues.Add(sqlReader.GetValue(i).ToString());
                        row.ColTypes.Add(sqlReader.GetFieldType(i));
                        row.ColNames.Add(table.Columns[i].ColName);
                    }
                    lsData.Add(row);
                }
               
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
            }
            
            return lsData;
        }
        private void getSchema(System.Data.DataTable table)
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
                        sqlTable.TableName = row[col].ToString();
                        DataTable fields = m_sqlCnn.sqlCNN.GetSchema(SqlClientMetaDataCollectionNames.Columns, new string[] { null, null, sqlTable.TableName });
                        try
                        {
                            foreach (DataRow dr in fields.Rows)
                            {
                                BmSQLColumnDataType sqlColumn = new BmSQLColumnDataType();
                                sqlColumn.ColName = dr["COLUMN_NAME"].ToString();
                                // sqlColumn.updateDataType(dr[7].ToString());
                                Debug.WriteLine(sqlColumn.ColName);
                                //get column type
                                string sql = "SELECT + [" + sqlColumn.ColName + "] FROM [" + sqlTable.TableName + "]";
                                SqlCommand sqlCMD = new SqlCommand(sql, m_sqlCnn.sqlCNN);
                                SqlDataReader sqlReader = sqlCMD.ExecuteReader(CommandBehavior.KeyInfo);
                                DataTable schemaDataType = sqlReader.GetSchemaTable();
                                //foreach (ForeignKeyConstraint fk in schemaDataType.Constraints)
                                //{
                                //    Debug.WriteLine("Contraints: " + fk.RelatedColumns[0] +  " - " + fk.RelatedColumns[1]);
                                //}
                                //foreach (DataRow type in schemaDataType.Rows)
                                if (schemaDataType.Rows.Count > 0)
                                {
                                    DataRow type = schemaDataType.Rows[0];

                                    foreach (DataColumn property in schemaDataType.Columns)
                                    {

                                        Debug.WriteLine(property.ColumnName + " : " + type[property].ToString());
                                        if (property.ColumnName.Equals("DataTypeName"))
                                        {
                                            sqlColumn.updateDataType(type[property].ToString());
                                        }
                                        else
                                        if (property.ColumnName.Equals("NumericPrecision"))
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

                                sqlReader.Close();

                                string sql2 = "SELECT f.name AS foreign_key_name ,OBJECT_NAME(f.parent_object_id) AS table_name " +
                                          ", COL_NAME(fc.parent_object_id, fc.parent_column_id) AS constraint_column_name" +
                                          "  , OBJECT_NAME (f.referenced_object_id) AS referenced_object " +
                                           "  , COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS referenced_column_name " +
                                        "FROM sys.foreign_keys AS f " +
                                        "INNER JOIN sys.foreign_key_columns AS fc " +
                                         "  ON f.object_id = fc.constraint_object_id " +
                                        "WHERE f.parent_object_id = OBJECT_ID('" + sqlTable.TableName + "') AND COL_NAME(fc.referenced_object_id, fc.referenced_column_id) = '" + sqlColumn.ColName + "'; ";
                                SqlCommand sqlCMD2 = new SqlCommand(sql2, m_sqlCnn.sqlCNN);
                                SqlDataReader sqlReader2 = sqlCMD2.ExecuteReader();
                                while (sqlReader2.Read())
                                {
                                    string foreign_key_name = sqlReader2["foreign_key_name"].ToString();
                                    string parent_table_name = sqlReader2["referenced_object"].ToString();
                                    string referenced_column_name = sqlReader2["referenced_column_name"].ToString();
                                    string constraint_column_name = sqlReader2["constraint_column_name"].ToString();
                                    sqlColumn.IsForeignKey = true;
                                    sqlColumn.ParentTableName = parent_table_name;
                                    sqlColumn.ReferenceColName = referenced_column_name;
                                    Debug.WriteLine("Forign Key: " + foreign_key_name);
                                    Debug.WriteLine("Parent Table: " + parent_table_name + " - Column Constraint:" + constraint_column_name + " --- Ref: " + referenced_column_name);
                                }
                                sqlReader2.Close();


                                sqlTable.Columns.Add(sqlColumn);
                            }
                        }
                        catch (Exception ex)
                        { }
                        
                        
                        
                    }
                    
                }
                if (sqlTable != null)
                {
                    sqlTable.Data = getData(sqlTable);
                    SqlSchema.Tables.Add(sqlTable);
                }
                Debug.WriteLine("============================");
            }
        }
    }

}
