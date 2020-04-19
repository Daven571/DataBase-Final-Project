namespace WindowsFormsApplication1
{
    partial class Inventory
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
            this.pnlReports = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttnExpenseRprt = new System.Windows.Forms.Button();
            this.bttnSalesRprt = new System.Windows.Forms.Button();
            this.bttnPandLRprt = new System.Windows.Forms.Button();
            this.bttnInventoryRprt = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReports.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReports
            // 
            this.pnlReports.Controls.Add(this.panel3);
            this.pnlReports.Controls.Add(this.bttnExpenseRprt);
            this.pnlReports.Controls.Add(this.bttnSalesRprt);
            this.pnlReports.Controls.Add(this.bttnPandLRprt);
            this.pnlReports.Controls.Add(this.bttnInventoryRprt);
            this.pnlReports.Location = new System.Drawing.Point(9, 32);
            this.pnlReports.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(423, 446);
            this.pnlReports.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(8, 109);
            this.panel3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 328);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(404, 328);
            this.dataGridView1.TabIndex = 0;
            // 
            // bttnExpenseRprt
            // 
            this.bttnExpenseRprt.Location = new System.Drawing.Point(111, 35);
            this.bttnExpenseRprt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bttnExpenseRprt.Name = "bttnExpenseRprt";
            this.bttnExpenseRprt.Size = new System.Drawing.Size(95, 34);
            this.bttnExpenseRprt.TabIndex = 3;
            this.bttnExpenseRprt.Text = "Expense Report";
            this.bttnExpenseRprt.UseVisualStyleBackColor = true;
            // 
            // bttnSalesRprt
            // 
            this.bttnSalesRprt.Location = new System.Drawing.Point(216, 35);
            this.bttnSalesRprt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bttnSalesRprt.Name = "bttnSalesRprt";
            this.bttnSalesRprt.Size = new System.Drawing.Size(95, 34);
            this.bttnSalesRprt.TabIndex = 2;
            this.bttnSalesRprt.Text = "Sales Report";
            this.bttnSalesRprt.UseVisualStyleBackColor = true;
            // 
            // bttnPandLRprt
            // 
            this.bttnPandLRprt.Location = new System.Drawing.Point(318, 35);
            this.bttnPandLRprt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bttnPandLRprt.Name = "bttnPandLRprt";
            this.bttnPandLRprt.Size = new System.Drawing.Size(95, 34);
            this.bttnPandLRprt.TabIndex = 1;
            this.bttnPandLRprt.Text = "Profit and Loss Report";
            this.bttnPandLRprt.UseVisualStyleBackColor = true;
            // 
            // bttnInventoryRprt
            // 
            this.bttnInventoryRprt.Location = new System.Drawing.Point(8, 35);
            this.bttnInventoryRprt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bttnInventoryRprt.Name = "bttnInventoryRprt";
            this.bttnInventoryRprt.Size = new System.Drawing.Size(95, 34);
            this.bttnInventoryRprt.TabIndex = 0;
            this.bttnInventoryRprt.Text = "Inventory Report";
            this.bttnInventoryRprt.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 542);
            this.Controls.Add(this.pnlReports);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.pnlReports.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttnExpenseRprt;
        private System.Windows.Forms.Button bttnSalesRprt;
        private System.Windows.Forms.Button bttnPandLRprt;
        private System.Windows.Forms.Button bttnInventoryRprt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
    }
}