namespace SQL2NonSQLConverter
{
    partial class frmDataViewer
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
            this.tvViewer = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvViewer
            // 
            this.tvViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvViewer.Location = new System.Drawing.Point(0, 0);
            this.tvViewer.Name = "tvViewer";
            this.tvViewer.Size = new System.Drawing.Size(282, 253);
            this.tvViewer.TabIndex = 0;
            // 
            // frmDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.tvViewer);
            this.Name = "frmDataViewer";
            this.Text = "frmDataViewer";
            this.Load += new System.EventHandler(this.frmDataViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvViewer;
    }
}