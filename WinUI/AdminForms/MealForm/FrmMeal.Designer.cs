namespace WinUI.AdminForms.MealForm
{
    partial class FrmMeal
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtMealName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMeal = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(496, 159);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 64);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 245);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(282, 64);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(350, 159);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(137, 64);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Yeni Oluştur";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtMealName
            // 
            this.txtMealName.Location = new System.Drawing.Point(350, 86);
            this.txtMealName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMealName.Name = "txtMealName";
            this.txtMealName.Size = new System.Drawing.Size(282, 27);
            this.txtMealName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Öğün Adı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Öğün Listesi :";
            // 
            // lstMeal
            // 
            this.lstMeal.FormattingEnabled = true;
            this.lstMeal.ItemHeight = 20;
            this.lstMeal.Location = new System.Drawing.Point(27, 86);
            this.lstMeal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstMeal.Name = "lstMeal";
            this.lstMeal.Size = new System.Drawing.Size(247, 384);
            this.lstMeal.TabIndex = 4;
            // 
            // FrmMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 494);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtMealName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMeal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMeal";
            this.Text = "FrmMeal";
            this.Load += new System.EventHandler(this.FrmMeal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCreate;
        private TextBox txtMealName;
        private Label label2;
        private Label label1;
        private ListBox lstMeal;
    }
}