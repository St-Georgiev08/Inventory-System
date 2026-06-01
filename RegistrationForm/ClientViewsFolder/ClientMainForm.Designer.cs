namespace RegistrationForm
{
    partial class ClientMainForm
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(344, 80);
            label1.Name = "label1";
            label1.Size = new Size(97, 46);
            label1.TabIndex = 0;
            label1.Text = "label";
            // 
            // button1
            // 
            button1.Location = new Point(429, 309);
            button1.Name = "button1";
            button1.Size = new Size(134, 53);
            button1.TabIndex = 1;
            button1.Text = "Show all orders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(431, 155);
            button2.Name = "button2";
            button2.Size = new Size(134, 55);
            button2.TabIndex = 2;
            button2.Text = "Shop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(431, 236);
            button3.Name = "button3";
            button3.Size = new Size(133, 51);
            button3.TabIndex = 3;
            button3.Text = "Update account";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(66, 323);
            label2.Name = "label2";
            label2.Size = new Size(276, 25);
            label2.TabIndex = 4;
            label2.Text = "See all your orders here ->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(66, 167);
            label3.Name = "label3";
            label3.Size = new Size(239, 25);
            label3.TabIndex = 5;
            label3.Text = "Go back to shopping->\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(66, 247);
            label4.Name = "label4";
            label4.Size = new Size(359, 25);
            label4.TabIndex = 6;
            label4.Text = "Make Changes on your account ->\r\n";
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkTurquoise;
            ClientSize = new Size(800, 451);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ClientMainForm";
            Text = "ClientMainForm";
            Load += ClientMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}