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
            pictureBox1.Location = new Point(14, 12);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(237, 176);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(549, 165);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(128, 34);
            button1.TabIndex = 1;
            button1.Text = "Buy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(327, 34);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 2;
            lblName.Text = "label1";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(327, 80);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(68, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "lblCategory";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(327, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "label3";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(549, 137);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(50, 23);
            numericUpDown1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Location = new Point(549, 119);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 6;
            label1.Text = "Count of the product";
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserControl1";
            Size = new Size(679, 201);
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
