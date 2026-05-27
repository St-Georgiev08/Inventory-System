using SalesSystem.Data.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class RegistrationForm2 : Form
    {
        public RegistrationForm2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = textBox2.Text;
            string passwordConfirm = textBox3.Text;
            string phone = textBox4.Text;
            string? email = textBox5.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm)
                || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("All fields are required except email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != passwordConfirm)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                return;
            }
            UsersCotroller userController = new();
            try
            {
                var m = await userController.AddUserAsync(username, password, "User", phone, email);
                MessageBox.Show(m, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                RegistrationForm1 registrationForm1 = new RegistrationForm1();
                registrationForm1.ShowDialog();
                this.Close();
            }
            catch (ArgumentException x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 registrationForm1 = new RegistrationForm1();
            registrationForm1.ShowDialog();
            this.Close();
        }
    }
}
