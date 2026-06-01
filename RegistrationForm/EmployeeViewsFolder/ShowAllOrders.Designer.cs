namespace RegistrationForm.EmployeeViewsFolder
{
    partial class ShowAllOrders
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
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(1, 1);
            button5.Name = "button5";
            button5.Size = new Size(115, 44);
            button5.TabIndex = 33;
            button5.Text = "Go back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.Location = new Point(700, 432);
            button3.Name = "button3";
            button3.Size = new Size(152, 61);
            button3.TabIndex = 43;
            button3.Text = "Close\r\n";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(155, 432);
            button2.Name = "button2";
            button2.Size = new Size(152, 61);
            button2.TabIndex = 42;
            button2.Text = "Export to EXCEL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(277, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 27);
            textBox2.TabIndex = 41;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(277, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(297, 27);
            textBox1.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(152, 64);
            label4.Name = "label4";
            label4.Size = new Size(414, 25);
            label4.TabIndex = 39;
            label4.Text = "Corect format (YYYY/MMMM/DDDD hh:mm:ss)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(152, 154);
            label3.Name = "label3";
            label3.Size = new Size(80, 25);
            label3.TabIndex = 38;
            label3.Text = "To date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(152, 110);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 37;
            label2.Text = "From date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(155, 197);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 36;
            label1.Text = "Orders log:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(155, 228);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 197);
            dataGridView1.TabIndex = 35;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(660, 110);
            button1.Name = "button1";
            button1.Size = new Size(192, 69);
            button1.TabIndex = 34;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ShowAllOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 557);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(button5);
            Name = "ShowAllOrders";
            Text = "ShowAllOrders";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button5;
        private Button button3;
        private Button button2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
    }
}