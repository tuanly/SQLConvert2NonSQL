using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL2NonSQLConverter
{
    public partial class frmDataViewer : Form
    {
        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {

        }

        public void ShowSQLViewer(List<BmSQLTableDataType> tables, string stTableName)
        {
            tvViewer.Nodes.Clear();
          

            foreach (BmSQLTableDataType table in tables)
            {
                if (table.TableName.Equals(stTableName))
                {
                    this.Text = stTableName;
                    int index = 0;
                    foreach (BmSQLDataRow row in table.Data)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = "row " + index;
                        for(int i = 0; i < row.ColNames.Count; i++)
                        {
                            TreeNode subNode = new TreeNode();
                            subNode.Text = row.ColNames[i] + " : " + row.ColValues[i];
                            node.Nodes.Add(subNode);
                        }

                        tvViewer.Nodes.Add(node);
                        index++;
                       
                    }
                   
                }
                
              

                
            }
            tvViewer.Refresh();
            this.Show();
        }


        public void ShowNonSQLViewer(TreeNode node, string stTableName)
        {
            tvViewer.Nodes.Clear();
            
            foreach (TreeNode subnode in node.Nodes)
            {
                if (subnode.Text.Equals(stTableName))
                {
                    this.Text = stTableName;
                    foreach (TreeNode n in subnode.Nodes)
                    {
                        
                        tvViewer.Nodes.Add((TreeNode)n.Clone());
                    }
                   
                }
            }
            tvViewer.Refresh();
            this.Show();
        }
    }
}
