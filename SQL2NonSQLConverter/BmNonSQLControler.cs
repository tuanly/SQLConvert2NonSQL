using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL2NonSQLConverter
{
    class BmNonSQLControler
    {
        private string m_stIP;
        private string m_stDBName;
        private string m_stPort;
        private BmConnection m_sqlCnn = null;
        private TreeNode m_treeData;

        public BmNonSQLControler()
        {
            m_stIP = "";
            m_stDBName = "";
            m_stPort = "";
            m_sqlCnn = new BmConnection();
            m_treeData = new TreeNode();
        }
        public BmNonSQLControler(string stIP, string stPort, string stDBName)
        {
            m_stIP = stIP;
            m_stDBName = stDBName;
            m_stPort = stPort;
            m_sqlCnn = new BmConnection();
            m_treeData = new TreeNode();


        }
        public void nonSQLInit()
        {
            m_sqlCnn.Connect2MongoDB(m_stIP, m_stPort, m_stDBName);
          
        }
        public bool convertSQL2NonSQLVer1(List<BmSQLTableDataType> tables, TreeView tree)
        {
            tree.Nodes.Clear();
            
            bool resutl = true;
            foreach (BmSQLTableDataType table in tables)
            {
                TreeNode node = new TreeNode();
                node.Text = table.TableName;
                //BmClassBuilder MCB = new BmClassBuilder("BookStore");
                //var myclass = MCB.CreateObject(new string[5] { "Id", "BookTitle", "Auther", "Category", "ISBN" }, new Type[5] { typeof(ObjectId), typeof(string), typeof(string), typeof(string), typeof(string) });
                //var myObject = Activator.CreateInstance(myclass.GetType());

                //myclass.GetType().GetProperty("BookTitle", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "dddMongoDB Basics", null);
                //myclass.GetType().GetProperty("ISBN", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "8767687689898yu", null);
                //myclass.GetType().GetProperty("Auther", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "Tanya", null);
                //myclass.GetType().GetProperty("Category", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "NoSQL DBMS", null);
                //var collection = mMongoDB.GetCollection("BookStore");


                //    collection.Save(myObject);
                BmClassBuilder MCB = new BmClassBuilder(table.TableName);
                string[] cols = new string[table.Columns.Count  +1];
                Type[] types = new Type[table.Columns.Count + 1];
                cols[0] = "Id";
                types[0] = typeof(ObjectId);
                string keyName = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    cols[i+1] = table.Columns[i].ColName;
                    bool isForeignKey = table.Columns[i].IsForeignKey;
                    if (isForeignKey)
                        types[i + 1] = typeof(BsonArray);
                    else
                        types[i+1] = table.Columns[i].getType();
                    if (table.Columns[i].IsKey)
                        keyName = table.Columns[i].ColName;
                }
                var myclass = MCB.CreateObject(cols, types);
                

                var collection = m_sqlCnn.nonSQLCNN.GetCollection(table.TableName);
                if (!keyName.Equals(""))
                    collection.EnsureIndex(IndexKeys.Ascending(keyName), IndexOptions.SetUnique(true));
                bool isUpdateTree = false;
                foreach (BmSQLDataRow row in table.Data)
                {
                    var myObject = Activator.CreateInstance(myclass.GetType());
                    for (int i = 0; i < row.ColValues.Count; i++)
                    {
                        TreeNode subNode = new TreeNode();
                        subNode.Text = table.Columns[i].ColName + " : " + convertDataName(table.Columns[i].DataTypeName);
                        //check foreign Key
                        bool isForeignKey = table.Columns[i].IsForeignKey;
                        
                        if (isForeignKey)
                        {
                            bool isParent = isParentTable(table.Columns[i].ParentTableName, tables);
                            subNode.Text = table.Columns[i].ColName + " : BsonArray";
                            BsonArray array = new BsonArray();
                            
                            if (isParent)
                            {
                                array.Add(new BsonDocument() { { "Parent_Table", table.Columns[i].ParentTableName } });
                                if (row.ColTypes[i] == typeof(string))
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, row.ColValues[i] } });
                                else if (row.ColTypes[i] == typeof(decimal))
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, Double.Parse(row.ColValues[i]) } });
                                else if (row.ColTypes[i] == typeof(bool))
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, Boolean.Parse(row.ColValues[i]) } });
                                else if (row.ColTypes[i] == typeof(DateTime))
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, DateTime.Parse(row.ColValues[i]) } });
                                else if (row.ColTypes[i] == typeof(int))
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, Int32.Parse(row.ColValues[i]) } });
                                else
                                    array.Add(new BsonDocument() { { table.Columns[i].ColName, null } });
                                TreeNode subChildNode1 = new TreeNode();
                                subChildNode1.Text = "Parent_Table : String ";
                                subNode.Nodes.Add(subChildNode1);
                                TreeNode subChildNode2 = new TreeNode();
                                subChildNode2.Text = table.Columns[i].ColName + " : " + convertDataName(table.Columns[i].DataTypeName);
                                subNode.Nodes.Add(subChildNode2);
                            }
                            else
                            {
                                List<BmSQLDataRow> newRows = getParentRow(table.Columns[i].ReferenceColName, row.ColValues[i], table.Columns[i].ParentTableName, tables);
                                foreach (BmSQLDataRow newRow in newRows)
                                {
                                    BsonArray subArray = new BsonArray();
                                    for (int j = 0; j < newRow.ColValues.Count; j++)
                                    {
                                        if (newRow.ColTypes[j] == typeof(string))
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], newRow.ColValues[j] } });
                                        else if (newRow.ColTypes[j] == typeof(decimal))
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], Double.Parse(newRow.ColValues[j]) } });
                                        else if (newRow.ColTypes[j] == typeof(bool))
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], Boolean.Parse(newRow.ColValues[j]) } });
                                        else if (newRow.ColTypes[j] == typeof(DateTime))
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], DateTime.Parse(newRow.ColValues[j]) } });
                                        else if (newRow.ColTypes[j] == typeof(int))
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], Int32.Parse(newRow.ColValues[j]) } });
                                        else
                                            subArray.Add(new BsonDocument() { { newRow.ColNames[j], null } });
                                        TreeNode subChildNode3 = new TreeNode();
                                        subChildNode3.Text = newRow.ColNames[j] + " : " + convertDataName(newRow.ColTypes[j]);
                                        subNode.Nodes.Add(subChildNode3);
                                    }
                                    
                                    array.Add(subArray);

                                   

                                }

                            }
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, array, null);
                        }
                        else if (row.ColTypes[i] == typeof(string))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, row.ColValues[i], null);
                        else if (row.ColTypes[i] == typeof(decimal))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Double.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(bool))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Boolean.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(DateTime))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, DateTime.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(int))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Int32.Parse(row.ColValues[i]), null);
                        else
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, null, null);
                        if (!isUpdateTree)
                        {
                            
                           

                            node.Nodes.Add(subNode);

                        }
                    }
                   
                    isUpdateTree = true;
                    collection.Insert(myObject);
                }



                //TreeNode node = new TreeNode();
                //node.Text = table.TableName;
                //foreach (BmSQLColumnDataType column in table.Columns)
                //{
                //    TreeNode subNode = new TreeNode();
                //    subNode.Text = column.ColName + " : " + column.DataTypeName;
                //    if (column.IsKey)
                //        subNode.Text += " - Primary Key";
                //    else if (column.IsForeignKey)
                //        subNode.Text += " - Foreign Key : (" + column.ParentTableName + "-" + column.ReferenceColName + ")";
                //    node.Nodes.Add(subNode);
                //}

                //tvSQLSchema.Nodes.Add(node);
                tree.Nodes.Add(node);
            }
            return resutl;
        }
        public bool convertSQL2NonSQLVer2(List<BmSQLTableDataType> tables, TreeView tree)
        {
            tree.Nodes.Clear();
            //check include tables
            m_treeData.Nodes.Clear();
            foreach (BmSQLTableDataType table in tables)
            {
                int removeTableIndex = 0;
                int numForeignKey = 0;
                string stParentTableName = "";
                string stForeignKeyName = "";
                foreach(BmSQLColumnDataType col in table.Columns)
                {
                    if (col.IsForeignKey)
                    {
                        numForeignKey++;
                        stParentTableName = col.ParentTableName;
                        stForeignKeyName = col.ColName;
                    }
                    if (numForeignKey == 0) removeTableIndex++;


                }
                if (numForeignKey == 1)
                {
                    bool noParent = false;

                    foreach (BmSQLTableDataType table1 in tables)
                    {
                        foreach (BmSQLColumnDataType col1 in table1.Columns)
                        {
                            if (col1.IsForeignKey && col1.ParentTableName.Equals(table.TableName))
                            {
                                noParent = true;
                                break;
                            }
                        }
                        if (noParent) break;
                    }

                    if (!noParent)
                    {
                        int tableIndex = 0;
                        foreach (BmSQLTableDataType table2 in tables)
                        {
                            if (table2.TableName.Equals(stParentTableName))
                            {
                                BmSQLColumnDataType newCol = new BmSQLColumnDataType();
                                newCol.DataType = BmSQLDataType.SQL_DATA_TYPE_ARRAY;
                                newCol.ColName = table.TableName;
                                newCol.IncludeTableName = table.TableName;
                                newCol.IncludeForeignKeyName = stForeignKeyName;
                                newCol.IsIncludeTable = true;
                                tables[tableIndex].Columns.Add(newCol);
                                tables[removeTableIndex].IsRemove = true;
                                break;
                            }
                            tableIndex++;

                        }
                    }
                }
                
            }
            bool resutl = true;
            foreach (BmSQLTableDataType table in tables)
            {
                if (table.IsRemove)
                    continue;
                TreeNode node = new TreeNode();
                node.Text = table.TableName;
                TreeNode nodeData = new TreeNode();
                nodeData.Text = table.TableName;
                //BmClassBuilder MCB = new BmClassBuilder("BookStore");
                //var myclass = MCB.CreateObject(new string[5] { "Id", "BookTitle", "Auther", "Category", "ISBN" }, new Type[5] { typeof(ObjectId), typeof(string), typeof(string), typeof(string), typeof(string) });
                //var myObject = Activator.CreateInstance(myclass.GetType());

                //myclass.GetType().GetProperty("BookTitle", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "dddMongoDB Basics", null);
                //myclass.GetType().GetProperty("ISBN", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "8767687689898yu", null);
                //myclass.GetType().GetProperty("Auther", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "Tanya", null);
                //myclass.GetType().GetProperty("Category", BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, "NoSQL DBMS", null);
                //var collection = mMongoDB.GetCollection("BookStore");


                //    collection.Save(myObject);
                BmClassBuilder MCB = new BmClassBuilder(table.TableName);
                string[] cols = new string[table.Columns.Count + 1];
                Type[] types = new Type[table.Columns.Count + 1];
                cols[0] = "Id";
                types[0] = typeof(ObjectId);
                string keyName = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    cols[i + 1] = table.Columns[i].ColName;
                    
                    if (table.Columns[i].IsIncludeTable)
                        types[i + 1] = typeof(BsonArray);
                    else
                        types[i + 1] = table.Columns[i].getType();
                    if (table.Columns[i].IsKey)
                        keyName = table.Columns[i].ColName;
                }
                var myclass = MCB.CreateObject(cols, types);


                var collection = m_sqlCnn.nonSQLCNN.GetCollection(table.TableName);
                if (!keyName.Equals(""))
                    collection.EnsureIndex(IndexKeys.Ascending(keyName), IndexOptions.SetUnique(true));
                bool isUpdateTree = false;
                int rowIndex = 0;
                foreach (BmSQLDataRow row in table.Data)
                {
                    try
                    {
                        var myObject = Activator.CreateInstance(myclass.GetType());
                    string primeyKeyValue = "";
                    TreeNode subNodeRow = new TreeNode();
                    subNodeRow.Text = "row " + rowIndex++;
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        TreeNode subNode = new TreeNode();
                        subNode.Text = table.Columns[i].ColName + " : " + convertDataName(table.Columns[i].DataTypeName);
                      

                        TreeNode subNodeData = new TreeNode();
                        if (i < table.Columns.Count - 1)
                            subNodeData.Text = table.Columns[i].ColName + " : " + row.ColValues[i];
                        //check foreign Key
                        if (table.Columns[i].IsKey)
                            primeyKeyValue = row.ColValues[i];

                        if (table.Columns[i].IsIncludeTable)
                        {
                          
                            subNode.Text = table.Columns[i].ColName + " : BsonArray";
                            subNodeData.Text = table.Columns[i].ColName;
                            BsonArray array = new BsonArray();
                          

                            List<BmSQLDataRow> newRows = getIncludedRow(table.Columns[i].IncludeForeignKeyName, primeyKeyValue, table.Columns[i].IncludeTableName, tables);
                            foreach (BmSQLDataRow newRow in newRows)
                            {
                                BsonArray subArray = new BsonArray();
                                for (int j = 0; j < newRow.ColValues.Count; j++)
                                {
                                    if (newRow.ColTypes[j] == typeof(string))
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], newRow.ColValues[j] } });
                                    else if (newRow.ColTypes[j] == typeof(decimal))
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], Double.Parse(newRow.ColValues[j]) } });
                                    else if (newRow.ColTypes[j] == typeof(bool))
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], Boolean.Parse(newRow.ColValues[j]) } });
                                    else if (newRow.ColTypes[j] == typeof(DateTime))
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], DateTime.Parse(newRow.ColValues[j]) } });
                                    else if (newRow.ColTypes[j] == typeof(int))
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], Int32.Parse(newRow.ColValues[j]) } });
                                    else
                                        subArray.Add(new BsonDocument() { { newRow.ColNames[j], null } });
                                    TreeNode subChildNode3 = new TreeNode();
                                    subChildNode3.Text = newRow.ColNames[j] + " : " + convertDataName(newRow.ColTypes[j]);
                                    subNode.Nodes.Add(subChildNode3);

                                    TreeNode subChildNodeData = new TreeNode();
                                    subChildNodeData.Text = newRow.ColNames[j] + newRow.ColValues[j];
                                    subNodeData.Nodes.Add(subChildNodeData);
                                }

                                array.Add(subArray);



                            }
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, array, null);
                        }
                        else if (row.ColTypes[i] == typeof(string))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, row.ColValues[i], null);
                        else if (row.ColTypes[i] == typeof(decimal))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Double.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(bool))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Boolean.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(DateTime))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, DateTime.Parse(row.ColValues[i]), null);
                        else if (row.ColTypes[i] == typeof(int))
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, Int32.Parse(row.ColValues[i]), null);
                        else
                            myclass.GetType().GetProperty(table.Columns[i].ColName, BindingFlags.Public | BindingFlags.Instance).SetValue(myObject, null, null);
                       
                         if (!isUpdateTree)
                        {



                            node.Nodes.Add(subNode);

                        }
                        subNodeRow.Nodes.Add(subNodeData);
                    }
                    nodeData.Nodes.Add(subNodeRow);
                    isUpdateTree = true;
                   
                        collection.Insert(myObject);
                    }
                    catch (Exception ex) { }
                    
                }



                //TreeNode node = new TreeNode();
                //node.Text = table.TableName;
                //foreach (BmSQLColumnDataType column in table.Columns)
                //{
                //    TreeNode subNode = new TreeNode();
                //    subNode.Text = column.ColName + " : " + column.DataTypeName;
                //    if (column.IsKey)
                //        subNode.Text += " - Primary Key";
                //    else if (column.IsForeignKey)
                //        subNode.Text += " - Foreign Key : (" + column.ParentTableName + "-" + column.ReferenceColName + ")";
                //    node.Nodes.Add(subNode);
                //}

                //tvSQLSchema.Nodes.Add(node);
                tree.Nodes.Add(node);
                m_treeData.Nodes.Add(nodeData);
            }
            return resutl;
        }
        private bool isParentTable(string stTableName, List<BmSQLTableDataType> tables)
        {           
            foreach (BmSQLTableDataType table in tables)
            {
                if (table.TableName.Equals(stTableName))
                {
                    foreach(BmSQLColumnDataType col in table.Columns)
                    {
                        if (col.IsForeignKey) return true;
                    }
                }
            }
            return false;
        }

        private BsonType convertDataName(Type type)
        {
            BsonType name = BsonType.String;
            if (type == typeof(int))
                name = BsonType.Int32;
            else if (type == typeof(DateTime))
                name = BsonType.DateTime;
            else if (type == typeof(bool))
                name = BsonType.Boolean;
            else if (type == typeof(decimal))
                name = BsonType.Double;
            return name;
        }
        private BsonType convertDataName(string type)
        {
            BsonType name = BsonType.String;
            if (type.Equals("int"))
                name = BsonType.Int32;
            else if (type.Equals("date")) 
                name = BsonType.DateTime;
            else if (type.Equals("datetime"))
                name = BsonType.DateTime;
            else if (type.Equals("bit"))
          
                name = BsonType.Boolean;
            else if (type.Equals("decimal"))
          
                name = BsonType.Double;
            return name;
        }
        private List<BmSQLDataRow> getParentRow(string colName, string value, string stTableName, List<BmSQLTableDataType> tables)
        {
            List<BmSQLDataRow> rows = new List<BmSQLDataRow>();
            foreach (BmSQLTableDataType table in tables)
            {
                if (table.TableName.Equals(stTableName))
                {
                    foreach (BmSQLDataRow dr in table.Data)
                    {
                        for (int i = 0; i < dr.ColValues.Count; i++)
                        {
                            if (table.Columns[i].ColName.Equals(colName) && dr.ColValues[i].Equals(value))
                            {
                                rows.Add(dr);
                            }
                        }
                        
                    }
                    
                }
            }
            return rows;
        }
        private List<BmSQLDataRow> getIncludedRow(string colName, string value, string stTableName, List<BmSQLTableDataType> tables)
        {
            List<BmSQLDataRow> rows = new List<BmSQLDataRow>();
            foreach (BmSQLTableDataType table in tables)
            {
                if (table.TableName.Equals(stTableName))
                {
                    foreach (BmSQLDataRow dr in table.Data)
                    {
                        for (int i = 0; i < dr.ColValues.Count; i++)
                        {
                            if (table.Columns[i].ColName.Equals(colName) && dr.ColValues[i].Equals(value))
                            {
                                rows.Add(dr);
                            }
                        }

                    }

                }
            }
            return rows;
        }
        public string IP
        {
            get { return m_stIP; }
            set { m_stIP = value; }
        }
        public string Port
        {
            get { return m_stPort; }
            set { m_stPort = value; }
        }
        public string DBName
        {
            get { return m_stDBName; }
            set { m_stDBName = value; }
        }

        internal BmConnection SqlCnn
        {
            get { return m_sqlCnn; }
            set { m_sqlCnn = value; }            
        }

        internal TreeNode TreeData
        {
            get { return m_treeData; }
            set { m_treeData = value; }
        }


    }
}
