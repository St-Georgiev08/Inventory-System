namespace RegistrationForm.ClientViewsFolder
{
    partial class AllClintsOrders
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
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(1, 2);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(101, 33);
            button5.TabIndex = 9;
            button5.Text = "Go back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // AllClintsOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Name = "AllClintsOrders";
            Text = "AllClintsOrders";
            ResumeLayout(false);
        }

        #endregion

        private Button button5;
    }
}