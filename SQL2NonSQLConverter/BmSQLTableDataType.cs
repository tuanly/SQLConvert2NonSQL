﻿using System;
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
        private List<BmSQLDataRow> m_lsData;

        public string TableName
        {
            get { return m_stTableName; }
            set { m_stTableName = value; }
        }
       

        public string Description
        {
            get { return m_stDescription; }
            set { m_stDescription = value; }
        }
        
        internal List<BmSQLColumnDataType> Columns
        {
            get { return m_lsColumn; }
            set { m_lsColumn = value; }
        }
        internal List<BmSQLDataRow> Data
        {
            get { return m_lsData; }
            set { m_lsData = value; }
        }

        public BmSQLTableDataType()
        {
            m_stDescription = "";
            m_stTableName = "";
            m_lsColumn = new List<BmSQLColumnDataType>();
            m_lsData = new List<BmSQLDataRow>();
        }

    }
}
