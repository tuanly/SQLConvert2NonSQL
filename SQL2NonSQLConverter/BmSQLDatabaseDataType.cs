using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2NonSQLConverter
{
    class BmSQLDatabaseDataType
    {
        private string m_stDatabaseName;
        private string m_stDescription;
        private List<BmSQLTableDataType> m_lsTables;

        public string DatabaseName
        {
            get { return m_stDatabaseName; }
            set { m_stDatabaseName = value; }
        }
        public string Description
        {
            get { return m_stDescription; }
            set { m_stDescription = value; }
        }
        internal List<BmSQLTableDataType> Tables
        {
            get { return m_lsTables; }
            set { m_lsTables = value; }
        }

        public BmSQLDatabaseDataType()
        {
            m_stDatabaseName = "";
            m_stDescription = "";

            m_lsTables = new List<BmSQLTableDataType>();
        }

       
    }
}
