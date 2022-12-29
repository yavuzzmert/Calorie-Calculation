namespace WinUI.AdminForms
{
    partial class AdminParent
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
            this.kullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yemekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıToolStripMenuItem,
            this.kategoriToolStripMenuItem,
            this.yemekToolStripMenuItem,
            this.öğünToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kullanıcıToolStripMenuItem
            // 
            this.kullanıcıToolStripMenuItem.Name = "kullanıcıToolStripMenuItem";
            this.kullanıcıToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.kullanıcıToolStripMenuItem.Tag = "user";
            this.kullanıcıToolStripMenuItem.Text = "Kullanıcı";
            // 
            // kategoriToolStripMenuItem
            // 
            this.kategoriToolStripMenuItem.Name = "kategoriToolStripMenuItem";
            this.kategoriToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.kategoriToolStripMenuItem.Tag = "category";
            this.kategoriToolStripMenuItem.Text = "Kategori";
            // 
            // yemekToolStripMenuItem
            // 
            this.yemekToolStripMenuItem.Name = "yemekToolStripMenuItem";
            this.yemekToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.yemekToolStripMenuItem.Tag = "food";
            this.yemekToolStripMenuItem.Text = "Yemek";
            // 
            // öğünToolStripMenuItem
            // 
            this.öğünToolStripMenuItem.Name = "öğünToolStripMenuItem";
            this.öğünToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.öğünToolStripMenuItem.Tag = "meal";
            this.öğünToolStripMenuItem.Text = "Öğün";
            // 
            // AdminParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminParent";
            this.Text = "AdminParent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem kullanıcıToolStripMenuItem;
        private ToolStripMenuItem kategoriToolStripMenuItem;
        private ToolStripMenuItem yemekToolStripMenuItem;
        private ToolStripMenuItem öğünToolStripMenuItem;
    }
}