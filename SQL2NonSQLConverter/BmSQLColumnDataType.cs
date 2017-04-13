using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2NonSQLConverter
{
    class BmSQLColumnDataType
    {
        private string m_stColName;        
        private int m_iColIndex;        
        private int m_iDataType;        
        private string m_stDataTypeName;       
        private int m_iNumericPrecision;       
        private int m_iNumericScale;       
        private bool m_bIsUnique;        
        private bool m_bIsKey;        
        private bool m_bIsIdentity;        
        private bool m_bIsAutoIncrement;        
        private bool m_bIsReadOnly;       
        private bool m_bIsForeignKey;        
        private string m_stParentTableName;        
        private string m_stReferenceColName;

       
        
        private string m_stIncludeTableName;
        private string m_stIncludeForeignKeyName;
        private bool m_bIsIncludeTable;

        public bool IsIncludeTable
        {
            get { return m_bIsIncludeTable; }
            set { m_bIsIncludeTable = value; }
        }
       
        public string IncludeTableName
        {
            get { return m_stIncludeTableName; }
            set { m_stIncludeTableName = value; }
        }
        public string IncludeForeignKeyName
        {
            get { return m_stIncludeForeignKeyName; }
            set { m_stIncludeForeignKeyName = value; }
        }
        public string ColName
        {
            get { return m_stColName; }
            set { m_stColName = value; }
        }
        public int ColIndex
        {
            get { return m_iColIndex; }
            set { m_iColIndex = value; }
        }
        public int DataType
        {
            get { return m_iDataType; }
            set { m_iDataType = value; }
        }
        public string DataTypeName
        {
            get { return m_stDataTypeName; }
            set { m_stDataTypeName = value; }
        }
        public int NumericPrecision
        {
            get { return m_iNumericPrecision; }
            set { m_iNumericPrecision = value; }
        }
        public int NumericScale
        {
            get { return m_iNumericScale; }
            set { m_iNumericScale = value; }
        }
        public bool IsUnique
        {
            get { return m_bIsUnique; }
            set { m_bIsUnique = value; }
        }
        public bool IsKey
        {
            get { return m_bIsKey; }
            set { m_bIsKey = value; }
        }
        private bool m_bAllowDBNull;

        public bool IsAllowDBNull
        {
            get { return m_bAllowDBNull; }
            set { m_bAllowDBNull = value; }
        }
        public bool IsIdentity
        {
            get { return m_bIsIdentity; }
            set { m_bIsIdentity = value; }
        }
        public bool IsAutoIncrement
        {
            get { return m_bIsAutoIncrement; }
            set { m_bIsAutoIncrement = value; }
        }
        public bool IsReadOnly
        {
            get { return m_bIsReadOnly; }
            set { m_bIsReadOnly = value; }
        }
        public bool IsForeignKey
        {
            get { return m_bIsForeignKey; }
            set { m_bIsForeignKey = value; }
        }
        public string ParentTableName
        {
            get { return m_stParentTableName; }
            set { m_stParentTableName = value; }
        }
        public string ReferenceColName
        {
            get { return m_stReferenceColName; }
            set { m_stReferenceColName = value; }
        }


        public BmSQLColumnDataType()
        {
            m_stColName = "";
            m_iDataType = BmSQLDataType.SQL_DATA_TYPE_INT;
            m_iColIndex = 0;
            m_stDataTypeName = "";
            m_iNumericPrecision = 0;
            m_iNumericScale = 0;
            m_bIsUnique = false;
            m_bIsKey = false;
            m_bAllowDBNull = false;
            m_bIsIdentity = false;
            m_bIsAutoIncrement = false;
            m_bIsReadOnly = false;
            m_bIsForeignKey = false;
            m_stParentTableName = "";
            m_stReferenceColName = "";
            m_stIncludeForeignKeyName = "";
            m_stIncludeTableName = "";
           
            m_bIsIncludeTable = false;
        }

        public void updateDataType(String stDataTypeName)
        {
            DataTypeName = stDataTypeName;
            if (stDataTypeName.Equals("decimal"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_NUMBER;
            }
            else if (stDataTypeName.Equals("nvarchar"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_VARCHAR;
            }
            else if (stDataTypeName.Equals("bit"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_BIT;
            }
            else if (stDataTypeName.Equals("date"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_DATE;
            }
            else if (stDataTypeName.Equals("datetime"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_DATETIME;
            }
            else if (stDataTypeName.Equals("int"))
            {
                DataType = BmSQLDataType.SQL_DATA_TYPE_INT;
            }
        }

        public Type getType()
        {
            Type type = typeof(string);
            if (DataTypeName.Equals("decimal"))
            {
                type = typeof(double);
            }
            else if (DataTypeName.Equals("nvarchar"))
            {
                type = typeof(string);
            }
            else if (DataTypeName.Equals("bit"))
            {
                type = typeof(bool);
            }
            else if (DataTypeName.Equals("date"))
            {
                type = typeof(DateTime);
            }
            else if (DataTypeName.Equals("datetime"))
            {
                type = typeof(DateTime);
            }
            else if (DataTypeName.Equals("int"))
            {
                type = typeof(int);
            }
            return type;
        }
      

    }
}
