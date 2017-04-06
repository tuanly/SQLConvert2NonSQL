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

        public BmSQLDatabaseDataType()
        {
            StDatabaseName = "";
            StDescription = "";

            m_lsTables = new List<BmSQLTableDataType>();
        }

        public string StDatabaseName { get => m_stDatabaseName; set => m_stDatabaseName = value; }
        public string StDescription { get => m_stDescription; set => m_stDescription = value; }
        internal List<BmSQLTableDataType> Tables { get => m_lsTables; set => m_lsTables = value; }
    }
}
