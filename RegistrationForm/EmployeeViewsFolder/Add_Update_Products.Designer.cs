namespace RegistrationForm
{
    partial class Add_Update_Products
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(205, 9);
            label1.Name = "label1";
            label1.Size = new Size(268, 31);
            label1.TabIndex = 0;
            label1.Text = "Add/Update Products";
            // 
            // button1
            // 
            button1.Location = new Point(6, 4);
            button1.Name = "button1";
            button1.Size = new Size(89, 36);
            button1.TabIndex = 1;
            button1.Text = "Go back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 100);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 2;
            label2.Text = "Name of the product:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 141);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 3;
            label3.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(104, 180);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Quantity:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 223);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 5;
            label5.Text = "Category:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(181, 220);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(104, 261);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 7;
            label6.Text = "Description:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(389, 100);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 8;
            label7.Text = "Upload image:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(171, 258);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(178, 49);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(472, 252);
            button2.Name = "button2";
            button2.Size = new Size(162, 55);
            button2.TabIndex = 10;
            button2.Text = "Add new product:";
            button2.UseVisualStyleBackColor = true;
            // 
            // Add_Update_Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Add_Update_Products";
            Text = "Add_Update_Products";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private Label label7;
        private RichTextBox richTextBox1;
        private Button button2;
    }
}