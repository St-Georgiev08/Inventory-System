namespace RegistrationForm.UserForms
{
    partial class UserControl2
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
            button2 = new Button();
            lblPrice = new Label();
            lblCategory = new Label();
            lblName = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button2.Location = new Point(606, 55);
            button2.Name = "button2";
            button2.Size = new Size(157, 61);
            button2.TabIndex = 23;
            button2.Text = "Update product";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPrice.Location = new Point(333, 153);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(60, 23);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "label3";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblCategory.Location = new Point(333, 93);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(109, 23);
            lblCategory.TabIndex = 21;
            lblCategory.Text = "lblCategory";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblName.Location = new Point(333, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 23);
            lblName.TabIndex = 20;
            lblName.Text = "label1";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button1.Location = new Point(606, 146);
            button1.Name = "button1";
            button1.Size = new Size(157, 61);
            button1.TabIndex = 19;
            button1.Text = "Delete product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(13, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(333, 209);
            label1.Name = "label1";
            label1.Size = new Size(60, 23);
            label1.TabIndex = 24;
            label1.Text = "label3";
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "UserControl2";
            Size = new Size(776, 268);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label lblPrice;
        private Label lblCategory;
        private Label lblName;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
