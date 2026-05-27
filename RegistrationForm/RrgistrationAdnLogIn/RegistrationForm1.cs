using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Data.Controllers;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public partial class RegistrationForm1 : Form
    {

        public RegistrationForm1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UsersCotroller user = new();
            string usernama = textBox1.Text;
            string password = textBox2.Text;
            User us = null;
            try
            {
                us = await user.AuthenticateUserAsync(usernama, password);
                MessageBox.Show($"Login successful for user: {us.Username}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentException x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                return;
            }
            if (us.Role == RoleType.Admin)
            {
                this.Hide();
                AdminCommandView adminCommandView = new AdminCommandView();
                adminCommandView.ShowDialog();
                this.Close();
            }
            //this.Hide();
            //MainForm mainForm = new MainForm();
            //mainForm.ShowDialog();
            //this.Close();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
