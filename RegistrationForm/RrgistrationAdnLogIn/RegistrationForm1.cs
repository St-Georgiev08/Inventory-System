using Inventory_System.Entities;
using Inventory_System.Enums;
using RegistrationForm.EmployeeViewsFolder;
using SalesSystem.Business.Controllers;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public partial class RegistrationForm1 : Form
    {
       public User GetUser { set; get; }
        public RegistrationForm1(User user)
        {
            InitializeComponent();
            GetUser = user;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UsersCotroller user = new();
            string usernama = textBox1.Text;
            string password = textBox2.Text;
            var us = new User();
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
                AdminCommandView adminCommandView = new AdminCommandView(us);
                adminCommandView.ShowDialog();
                this.Close();
            }
            if (us.Role == RoleType.Client)
            {
                this.Hide();
                ShopItems clientMainForm = new ShopItems(us);
                clientMainForm.ShowDialog();
                this.Close();
            }
            if (us.Role == RoleType.Employee)
            {
                this.Hide();
                EmployeeCommandsView view = new EmployeeCommandsView(us);
                view.ShowDialog();
                this.Close();
            }
            //this.Hide();
            //MainForm mainForm = new MainForm();
            //mainForm.ShowDialog();
            //this.Close();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm2 registrationForm2 = new RegistrationForm2();
            registrationForm2.ShowDialog();
            this.Close();

        }

        private void RegistrationForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
