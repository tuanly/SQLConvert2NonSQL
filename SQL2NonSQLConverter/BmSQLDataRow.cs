using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2NonSQLConverter
{
    class BmSQLDataRow
    {
     
        private List<String> m_lsColValues;
        private List<Type> m_lsColTypes;
        private List<String> m_lsColNames;

        public BmSQLDataRow()
        {
            m_lsColValues = new List<string>();
            m_lsColTypes = new List<Type>();
            m_lsColNames = new List<string>();
        }

        internal List<string> ColValues
        {
            get { return m_lsColValues; }
            set { m_lsColValues = value; }         
        }
        internal List<Type> ColTypes
        {
            get { return m_lsColTypes; }
            set { m_lsColTypes = value; }
        }
        internal List<String> ColNames
        {
            get { return m_lsColNames; }
            set { m_lsColNames = value; }
        }
    }
}
