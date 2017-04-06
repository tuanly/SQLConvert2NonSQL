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
        private bool m_bAllowDBNull;
        private bool m_bIsIdentity;
        private bool m_bIsAutoIncrement;
        private bool m_bIsReadOnly;

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
        }

        public void updateDataType(String stDataTypeName)
        {
            m_stDataTypeName = stDataTypeName;
            if (stDataTypeName.Equals("decimal"))
            {
                m_iDataType = BmSQLDataType.SQL_DATA_TYPE_NUMBER;
            }
            else if (stDataTypeName.Equals("nvarchar"))
            {
                m_iDataType = BmSQLDataType.SQL_DATA_TYPE_VARCHAR;
            }
            else if (stDataTypeName.Equals("bit"))
            {
                m_iDataType = BmSQLDataType.SQL_DATA_TYPE_BIT;
            }
            else if (stDataTypeName.Equals("date"))
            {
                m_iDataType = BmSQLDataType.SQL_DATA_TYPE_DATE;
            }
            else if (stDataTypeName.Equals("int"))
            {
                m_iDataType = BmSQLDataType.SQL_DATA_TYPE_INT;
            }
        }

        public string ColName { get => m_stColName; set => m_stColName = value; }
        public int ColIndex { get => m_iColIndex; set => m_iColIndex = value; }
        public int DataType { get => m_iDataType; set => m_iDataType = value; }
        public int NumericPrecision { get => m_iNumericPrecision; set => m_iNumericPrecision = value; }
        public int NumericScale { get => m_iNumericScale; set => m_iNumericScale = value; }
        public bool IsUnique { get => m_bIsUnique; set => m_bIsUnique = value; }
        public bool IsKey { get => m_bIsKey; set => m_bIsKey = value; }
        public bool ISAllowDBNull { get => m_bAllowDBNull; set => m_bAllowDBNull = value; }
        public bool IsIdentity { get => m_bIsIdentity; set => m_bIsIdentity = value; }
        public bool IsAutoIncrement { get => m_bIsAutoIncrement; set => m_bIsAutoIncrement = value; }
        public bool IsReadOnly { get => m_bIsReadOnly; set => m_bIsReadOnly = value; }
        public string DataTypeName { get => m_stDataTypeName; set => m_stDataTypeName = value; }
    }
}
