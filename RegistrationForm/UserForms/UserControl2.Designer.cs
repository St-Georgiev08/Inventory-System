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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(606, 46);
            button2.Name = "button2";
            button2.Size = new Size(157, 61);
            button2.TabIndex = 23;
            button2.Text = "Update order";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(370, 172);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(50, 20);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "label3";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(370, 108);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(86, 20);
            lblCategory.TabIndex = 21;
            lblCategory.Text = "lblCategory";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(370, 46);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 20;
            lblName.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(606, 131);
            button1.Name = "button1";
            button1.Size = new Size(157, 61);
            button1.TabIndex = 19;
            button1.Text = "Finish order";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(13, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 235);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
