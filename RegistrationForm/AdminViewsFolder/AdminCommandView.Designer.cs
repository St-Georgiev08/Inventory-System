namespace RegistrationForm
{
    partial class AdminCommandView
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
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(227, 49);
            label1.Name = "label1";
            label1.Size = new Size(313, 41);
            label1.TabIndex = 0;
            label1.Text = "Admin control tablet";
            // 
            // button1
            // 
            button1.Location = new Point(189, 161);
            button1.Name = "button1";
            button1.Size = new Size(106, 66);
            button1.TabIndex = 1;
            button1.Text = "Add/Update Employee";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(460, 161);
            button2.Name = "button2";
            button2.Size = new Size(105, 66);
            button2.TabIndex = 2;
            button2.Text = "Show event log";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(189, 286);
            button3.Name = "button3";
            button3.Size = new Size(106, 66);
            button3.TabIndex = 3;
            button3.Text = "See all orders";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(460, 286);
            button4.Name = "button4";
            button4.Size = new Size(105, 66);
            button4.TabIndex = 4;
            button4.Text = "See all employees";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(12, 12);
            button5.Name = "button5";
            button5.Size = new Size(103, 34);
            button5.TabIndex = 5;
            button5.Text = "Log out";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // AdminCommandView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            HelpButton = true;
            Name = "AdminCommandView";
            Text = "AdminCommandView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}