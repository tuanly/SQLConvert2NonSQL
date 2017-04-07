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
            //bool restult = BmConnection.Connect2SQLServer(txtSQLServerName.Text,txtSQLServereUsername.Text, txtSQLServerPwd.Text);
            //MessageBox.Show(restult + "");
            //BmConnection.Connect2MongoDB();
            BmSQLControler sqlControler = new BmSQLControler(txtSQLServerName.Text, txtDBName.Text, txtSQLServereUsername.Text, txtSQLServerPwd.Text);
            sqlControler.sqlInit();

            foreach (BmSQLTableDataType table in sqlControler.SqlSchema.Tables)
            {
                TreeNode node = new TreeNode();
                node.Text = table.StTableName;
                foreach (BmSQLColumnDataType column in table.Columns)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = column.ColName + " : " + column.DataTypeName;
                    if (column.IsKey)
                        subNode.Text += " - Primary Key";
                    else if (column.IsForeignKey)
                        subNode.Text += " - Foreign Key : (" + column.ParentTableName + "-" + column.ReferenceColName + ")" ;
                    node.Nodes.Add(subNode);
                }

                tvSQLSchema.Nodes.Add(node);
            }
        }
    }
}
