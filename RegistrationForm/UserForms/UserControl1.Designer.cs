namespace RegistrationForm.UserForms
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            button1 = new Button();
            lblName = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(16, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(611, 220);
            button1.Name = "button1";
            button1.Size = new Size(146, 45);
            button1.TabIndex = 1;
            button1.Text = "Buy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblName.Location = new Point(374, 45);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 23);
            lblName.TabIndex = 2;
            lblName.Text = "label1";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblCategory.Location = new Point(374, 107);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(109, 23);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "lblCategory";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPrice.Location = new Point(374, 171);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(60, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "label3";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numericUpDown1.Location = new Point(659, 185);
            numericUpDown1.Margin = new Padding(3, 5, 3, 5);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(65, 34);
            numericUpDown1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(611, 160);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 6;
            label1.Text = "Count of the product";
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "UserControl1";
            Size = new Size(776, 268);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
            
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label lblName;
        private Label lblCategory;
        private Label lblPrice;
        private NumericUpDown numericUpDown1;
        private Label label1;
    }
}
