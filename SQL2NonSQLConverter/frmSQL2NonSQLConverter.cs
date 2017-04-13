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
        BmSQLControler m_sqlControler = null;
        BmNonSQLControler m_nonSQLControler = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //bool restult = BmConnection.Connect2SQLServer(txtSQLServerName.Text,txtSQLServereUsername.Text, txtSQLServerPwd.Text);
            //MessageBox.Show(restult + "");
            //BmConnection.Connect2MongoDB();
            tvSQLSchema.Nodes.Clear();
            m_sqlControler = new BmSQLControler(txtSQLServerName.Text, txtDBName.Text, txtSQLServereUsername.Text, txtSQLServerPwd.Text);
            m_sqlControler.sqlInit();

            foreach (BmSQLTableDataType table in m_sqlControler.SqlSchema.Tables)
            {
                TreeNode node = new TreeNode();
                node.Text = table.TableName;
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (m_sqlControler != null)
            {
                
                m_nonSQLControler = new BmNonSQLControler(txtMongoServerIP.Text, txtMongoDBPort.Text, txtDBName.Text);
                m_nonSQLControler.nonSQLInit();
                m_nonSQLControler.convertSQL2NonSQLVer2(m_sqlControler.SqlSchema.Tables, tvNonSQLSchema);

            }
            
        }

        private void cmnSQL_Click(object sender, EventArgs e)
        {          
            frmDataViewer frmData = new frmDataViewer();
            frmData.ShowSQLViewer(m_sqlControler.SqlSchema.Tables, tvSQLSchema.SelectedNode.Text);
        }

        private void cmnNonSQL_Click(object sender, EventArgs e)
        {
            frmDataViewer frmData = new frmDataViewer();
            frmData.ShowNonSQLViewer(m_nonSQLControler.TreeData, tvNonSQLSchema.SelectedNode.Text);
        }
    }
}
