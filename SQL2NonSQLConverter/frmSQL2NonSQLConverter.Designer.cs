namespace SQL2NonSQLConverter
{
    partial class frmSQL2NonSQLConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSQLServereUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtSQLServerPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSQLServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvSQLSchema = new System.Windows.Forms.TreeView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMongoDBPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMongoServerIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tvNonSQLSchema = new System.Windows.Forms.TreeView();
            this.cmnSQL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.submnViewSQLData = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnNonSQL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.submnNonSQL = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmnSQL.SuspendLayout();
            this.cmnNonSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(957, 562);
            this.splitContainer1.SplitterDistance = 470;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tvSQLSchema);
            this.splitContainer2.Size = new System.Drawing.Size(470, 562);
            this.splitContainer2.SplitterDistance = 179;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSQLServereUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtSQLServerPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSQLServerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(470, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(149, 61);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(295, 22);
            this.txtDBName.TabIndex = 8;
            this.txtDBName.Text = "bmdb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Database name:";
            // 
            // txtSQLServereUsername
            // 
            this.txtSQLServereUsername.Location = new System.Drawing.Point(131, 88);
            this.txtSQLServereUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtSQLServereUsername.Name = "txtSQLServereUsername";
            this.txtSQLServereUsername.Size = new System.Drawing.Size(313, 22);
            this.txtSQLServereUsername.TabIndex = 6;
            this.txtSQLServereUsername.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "User Name:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(217, 147);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSQLServerPwd
            // 
            this.txtSQLServerPwd.Location = new System.Drawing.Point(131, 117);
            this.txtSQLServerPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtSQLServerPwd.Name = "txtSQLServerPwd";
            this.txtSQLServerPwd.PasswordChar = '*';
            this.txtSQLServerPwd.Size = new System.Drawing.Size(313, 22);
            this.txtSQLServerPwd.TabIndex = 3;
            this.txtSQLServerPwd.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // txtSQLServerName
            // 
            this.txtSQLServerName.Location = new System.Drawing.Point(131, 31);
            this.txtSQLServerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSQLServerName.Name = "txtSQLServerName";
            this.txtSQLServerName.Size = new System.Drawing.Size(313, 22);
            this.txtSQLServerName.TabIndex = 1;
            this.txtSQLServerName.Text = "UITIS-LAB\\SQLEXPRESS2008";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server:";
            // 
            // tvSQLSchema
            // 
            this.tvSQLSchema.ContextMenuStrip = this.cmnSQL;
            this.tvSQLSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSQLSchema.Location = new System.Drawing.Point(0, 0);
            this.tvSQLSchema.Name = "tvSQLSchema";
            this.tvSQLSchema.Size = new System.Drawing.Size(470, 378);
            this.tvSQLSchema.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tvNonSQLSchema);
            this.splitContainer3.Size = new System.Drawing.Size(482, 562);
            this.splitContainer3.SplitterDistance = 183;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMongoDBPort);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMongoServerIP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(482, 183);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MongoDB";
            // 
            // txtMongoDBPort
            // 
            this.txtMongoDBPort.Location = new System.Drawing.Point(118, 63);
            this.txtMongoDBPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtMongoDBPort.Name = "txtMongoDBPort";
            this.txtMongoDBPort.Size = new System.Drawing.Size(313, 22);
            this.txtMongoDBPort.TabIndex = 9;
            this.txtMongoDBPort.Text = "27017";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Port";
            // 
            // txtMongoServerIP
            // 
            this.txtMongoServerIP.Location = new System.Drawing.Point(118, 31);
            this.txtMongoServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMongoServerIP.Name = "txtMongoServerIP";
            this.txtMongoServerIP.Size = new System.Drawing.Size(313, 22);
            this.txtMongoServerIP.TabIndex = 7;
            this.txtMongoServerIP.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "IP Address:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(163, 115);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(100, 28);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tvNonSQLSchema
            // 
            this.tvNonSQLSchema.ContextMenuStrip = this.cmnNonSQL;
            this.tvNonSQLSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNonSQLSchema.Location = new System.Drawing.Point(0, 0);
            this.tvNonSQLSchema.Name = "tvNonSQLSchema";
            this.tvNonSQLSchema.Size = new System.Drawing.Size(482, 374);
            this.tvNonSQLSchema.TabIndex = 1;
            // 
            // cmnSQL
            // 
            this.cmnSQL.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submnViewSQLData});
            this.cmnSQL.Name = "cmnSQL";
            this.cmnSQL.Size = new System.Drawing.Size(153, 30);
            this.cmnSQL.Click += new System.EventHandler(this.cmnSQL_Click);
            // 
            // submnViewSQLData
            // 
            this.submnViewSQLData.Name = "submnViewSQLData";
            this.submnViewSQLData.Size = new System.Drawing.Size(152, 26);
            this.submnViewSQLData.Text = "View Data";
            // 
            // cmnNonSQL
            // 
            this.cmnNonSQL.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnNonSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submnNonSQL});
            this.cmnNonSQL.Name = "cmnNonSQL";
            this.cmnNonSQL.Size = new System.Drawing.Size(153, 30);
            this.cmnNonSQL.Click += new System.EventHandler(this.cmnNonSQL_Click);
            // 
            // submnNonSQL
            // 
            this.submnNonSQL.Name = "submnNonSQL";
            this.submnNonSQL.Size = new System.Drawing.Size(181, 26);
            this.submnNonSQL.Text = "View Data";
            // 
            // frmSQL2NonSQLConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 562);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSQL2NonSQLConverter";
            this.Text = "SQL to Non-SQL Converter";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmnSQL.ResumeLayout(false);
            this.cmnNonSQL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSQLServerPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSQLServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtSQLServereUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvSQLSchema;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtMongoServerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMongoDBPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView tvNonSQLSchema;
        private System.Windows.Forms.ContextMenuStrip cmnSQL;
        private System.Windows.Forms.ToolStripMenuItem submnViewSQLData;
        private System.Windows.Forms.ContextMenuStrip cmnNonSQL;
        private System.Windows.Forms.ToolStripMenuItem submnNonSQL;
    }
}

