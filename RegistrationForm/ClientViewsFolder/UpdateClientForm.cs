using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Data.Controllers;
using SalesSystem.Data.HelpMethods;
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
        private RegistrationForm1 form1 = new();
        private User User {  get; set; }
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
                if (await hashing.VerifyPassword(textBox3.Text, textBox4.Text))
                {
                    MessageBox.Show(await users.UpdateUserAsync(user.Id, name, textBox2.Text, RoleType.Client.ToString(), ph, email)); return;
                }
                MessageBox.Show("The reentered password was misspelled! Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = "";
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
    }
}
