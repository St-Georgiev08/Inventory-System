namespace RegistrationForm.UserForms
{
    partial class UserControl4
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(324, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 15);
            lblPrice.TabIndex = 21;
            lblPrice.Text = "label3";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(324, 80);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(68, 15);
            lblCategory.TabIndex = 20;
            lblCategory.Text = "lblCategory";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(324, 34);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 19;
            lblName.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(530, 80);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(137, 46);
            button1.TabIndex = 18;
            button1.Text = "Delete order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(11, 12);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(237, 176);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // UserControl4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPrice);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "UserControl4";
            Size = new Size(679, 201);
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
    }
}
