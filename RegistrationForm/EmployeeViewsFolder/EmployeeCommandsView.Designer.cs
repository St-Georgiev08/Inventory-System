namespace RegistrationForm.EmployeeViewsFolder
{
    partial class EmployeeCommandsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeCommandsView));
            button5 = new Button();
            button3 = new Button();
            label1 = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            button6 = new Button();
            button7 = new Button();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(14, 15);
            button5.Name = "button5";
            button5.Size = new Size(103, 35);
            button5.TabIndex = 6;
            button5.Text = "Log out";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(105, 233);
            button3.Name = "button3";
            button3.Size = new Size(146, 91);
            button3.TabIndex = 9;
            button3.Text = "Add product in store";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(59, 136);
            label1.Name = "label1";
            label1.Size = new Size(763, 41);
            label1.TabIndex = 10;
            label1.Text = "This label changes according to the employee's name";
            // 
            // button6
            // 
            button6.Location = new Point(606, 233);
            button6.Name = "button6";
            button6.Size = new Size(146, 91);
            button6.TabIndex = 12;
            button6.Text = "Update/Add new category";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(354, 233);
            button7.Name = "button7";
            button7.Size = new Size(146, 91);
            button7.TabIndex = 13;
            button7.Text = "All products in system";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.BlanchedAlmond;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(699, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 132);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(232, 360);
            button1.Name = "button1";
            button1.Size = new Size(146, 91);
            button1.TabIndex = 7;
            button1.Text = "View all orders/ update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(495, 360);
            button4.Name = "button4";
            button4.Size = new Size(146, 91);
            button4.TabIndex = 11;
            button4.Text = "View orders";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // EmployeeCommandsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(857, 497);
            Controls.Add(pictureBox1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button5);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeCommandsView";
            Text = "EmployeeCommandsView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button button3;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button button6;
        private Button button7;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button4;
    }
}