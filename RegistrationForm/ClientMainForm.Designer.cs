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
            button4 = new Button();
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
            button1.Size = new Size(134, 54);
            button1.TabIndex = 1;
            button1.Text = "Show all orders";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(431, 154);
            button2.Name = "button2";
            button2.Size = new Size(134, 55);
            button2.TabIndex = 2;
            button2.Text = "New order";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(431, 236);
            button3.Name = "button3";
            button3.Size = new Size(132, 50);
            button3.TabIndex = 3;
            button3.Text = "Update account";
            button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(66, 322);
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
            label3.Size = new Size(206, 25);
            label3.TabIndex = 5;
            label3.Text = "Make new order ->\r\n";
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
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(110, 39);
            button4.TabIndex = 7;
            button4.Text = "Go back";
            button4.UseVisualStyleBackColor = true;
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Brown;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ClientMainForm";
            Text = "ClientMainForm";
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
        private Button button4;
    }
}