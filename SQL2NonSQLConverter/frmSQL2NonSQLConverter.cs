using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SQL2NonSQLConverter
{
    public partial class frmSQL2NonSQLConverter : Form
    {
        public frmSQL2NonSQLConverter()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool restult = BmConnection.Connect2SQLServer(txtSQLServerName.Text,txtSQLServereUsername.Text, txtSQLServerPwd.Text);
            MessageBox.Show(restult + "");
            BmConnection.Connect2MongoDB();
        }
    }
}
