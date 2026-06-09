namespace RegistrationForm.UserForms
{
    partial class UserControl3
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
            lblPrice = new Label();
            lblCategory = new Label();
            lblName = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrice.Location = new Point(370, 176);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(70, 28);
            lblPrice.TabIndex = 16;
            lblPrice.Text = "label3";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategory.Location = new Point(370, 107);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(122, 28);
            lblCategory.TabIndex = 15;
            lblCategory.Text = "lblCategory";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Location = new Point(370, 45);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 28);
            lblName.TabIndex = 14;
            lblName.Text = "label1";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(606, 130);
            button1.Name = "button1";
            button1.Size = new Size(157, 61);
            button1.TabIndex = 13;
            button1.Text = "Finish order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(13, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(606, 45);
            button2.Name = "button2";
            button2.Size = new Size(157, 61);
            button2.TabIndex = 17;
            button2.Text = "Update order";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserControl3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControl3";
            Size = new Size(776, 268);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblPrice;
        private Label lblCategory;
        private Label lblName;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
    }
}
