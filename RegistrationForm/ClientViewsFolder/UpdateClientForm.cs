using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Business.Controllers;
using SalesSystem.Business.HelpMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.ClientViewsFolder
{
    public partial class UpdateClientForm : Form
    {

        private User User { get; set; }
        public UpdateClientForm(User user)
        {
            InitializeComponent();
            User = user;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShopItems shop = new ShopItems(User);
            shop.ShowDialog();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            User user = User;
            string name = textBox1.Text;
            string? email = textBox4.Text;
            string ph = textBox5.Text;
            UsersCotroller users = new();
            try
            {
                HashingPaswords hashing = new();
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("The reentered password was misspelled! Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Text = "";
                }
                MessageBox.Show(await users.UpdateUserAsync(user.Id, name, textBox2.Text, RoleType.Client.ToString(), ph, email));
            }
            catch (ArgumentException x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateClientForm_Load(object sender, EventArgs e)
        {

            User user = User;
            textBox1.Text = user.Username;
            textBox4.Text = user.Email;
            textBox5.Text = user.PhoneNumber;
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientMainForm form = new(User);
            form.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
                return;
            }
            textBox2.PasswordChar = '\0';
            textBox3.PasswordChar = '\0';
        }
    }
}
