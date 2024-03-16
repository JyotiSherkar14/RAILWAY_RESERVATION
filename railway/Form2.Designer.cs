namespace railway
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tRAINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESERVATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERCAREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tRAINToolStripMenuItem,
            this.rESERVATIONToolStripMenuItem,
            this.cUSTOMERCAREToolStripMenuItem,
            this.dELETEToolStripMenuItem,
            this.rEPORTSToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tRAINToolStripMenuItem
            // 
            this.tRAINToolStripMenuItem.Name = "tRAINToolStripMenuItem";
            this.tRAINToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.tRAINToolStripMenuItem.Text = "Train";
            this.tRAINToolStripMenuItem.Click += new System.EventHandler(this.tRAINToolStripMenuItem_Click);
            // 
            // rESERVATIONToolStripMenuItem
            // 
            this.rESERVATIONToolStripMenuItem.Name = "rESERVATIONToolStripMenuItem";
            this.rESERVATIONToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.rESERVATIONToolStripMenuItem.Text = "Reservation";
            this.rESERVATIONToolStripMenuItem.Click += new System.EventHandler(this.rESERVATIONToolStripMenuItem_Click);
            // 
            // cUSTOMERCAREToolStripMenuItem
            // 
            this.cUSTOMERCAREToolStripMenuItem.Name = "cUSTOMERCAREToolStripMenuItem";
            this.cUSTOMERCAREToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.cUSTOMERCAREToolStripMenuItem.Text = "Customer Care";
            this.cUSTOMERCAREToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERCAREToolStripMenuItem_Click);
            // 
            // dELETEToolStripMenuItem
            // 
            this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
            this.dELETEToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.dELETEToolStripMenuItem.Text = "Delete";
            this.dELETEToolStripMenuItem.Click += new System.EventHandler(this.dELETEToolStripMenuItem_Click);
            // 
            // rEPORTSToolStripMenuItem
            // 
            this.rEPORTSToolStripMenuItem.Name = "rEPORTSToolStripMenuItem";
            this.rEPORTSToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.rEPORTSToolStripMenuItem.Text = "Reports";
            this.rEPORTSToolStripMenuItem.Click += new System.EventHandler(this.rEPORTSToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.eXITToolStripMenuItem.Text = "Exit";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 505);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tRAINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESERVATIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERCAREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
    }
}