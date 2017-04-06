using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2NonSQLConverter
{
    class BmSQLTableDataType
    {
        private string m_stTableName;
        private string m_stDescription;
        private List<BmSQLColumnDataType> m_lsColumn;

        public BmSQLTableDataType()
        {
            StDescription = "";
            StTableName = "";
            m_lsColumn = new List<BmSQLColumnDataType>();
        }

        public string StTableName { get => m_stTableName; set => m_stTableName = value; }
        public string StDescription { get => m_stDescription; set => m_stDescription = value; }
        internal List<BmSQLColumnDataType> Columns { get => m_lsColumn; set => m_lsColumn = value; }
    }
}
