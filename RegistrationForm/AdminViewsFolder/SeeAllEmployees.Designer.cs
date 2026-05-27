namespace RegistrationForm
{
    partial class SeeAllEmployees
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label2 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(52, 163);
            label1.Name = "label1";
            label1.Size = new Size(118, 28);
            label1.TabIndex = 20;
            label1.Text = "Employees:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 194);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 182);
            dataGridView1.TabIndex = 19;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(528, 73);
            button1.Name = "button1";
            button1.Size = new Size(192, 70);
            button1.TabIndex = 18;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(52, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 70);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sort by:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10.8F);
            radioButton1.Location = new Point(15, 36);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(84, 29);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Name:";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10.8F);
            radioButton2.Location = new Point(206, 36);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(176, 29);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Name descending";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(52, 124);
            label2.Name = "label2";
            label2.Size = new Size(57, 28);
            label2.TabIndex = 22;
            label2.Text = "Find:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 125);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 27);
            textBox1.TabIndex = 23;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(611, 382);
            button2.Name = "button2";
            button2.Size = new Size(139, 56);
            button2.TabIndex = 24;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.Location = new Point(52, 382);
            button3.Name = "button3";
            button3.Size = new Size(163, 56);
            button3.TabIndex = 25;
            button3.Text = "Export to EXCEL";
            button3.UseVisualStyleBackColor = true;
            // 
            // SeeAllEmployees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "SeeAllEmployees";
            Text = "SeeAllEmployees";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
    }
}