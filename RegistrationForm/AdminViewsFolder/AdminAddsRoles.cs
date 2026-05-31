using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Data.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RegistrationForm
{
    public partial class AdminAddsRoles : Form
    {
        private AdminCommandView adminCommandView = new();
        public AdminAddsRoles()
        {
            InitializeComponent();
            OnLoad();
        }
        private void OnLoad()
        {
            var reason = adminCommandView.GetReasonForClick;
            if (reason == "Add")
            {
                label2.Visible = true;
                textBox1.Visible = true;
                label10.Visible = false;
                listBox1.Visible = false;
                textBox6.Visible = false;
            }
            else
            {
                label2.Visible = false;
                textBox1.Visible = false;
                label10.Visible = true;
                listBox1.Visible = true;
                textBox6.Visible = true;
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Role must be picked!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username;
            string password = textBox2.Text;
            string reenter = textBox3.Text;
            string Email = textBox4.Text;
            string phoneNumber = textBox5.Text;
            bool Admin = radioButton1.Checked;
            bool Employee = radioButton2.Checked;
            string role = "";
            if (Admin)
            {
                role = "Admin";
            }
            else
            {
                role = "Employee";
            }
            AuditLogsController auditLogsController = new AuditLogsController();
            UsersCotroller control = new();
            RegistrationForm1 form = new RegistrationForm1();
            if (adminCommandView.GetReasonForClick == "Add")
            {
                 username = textBox1.Text;
                try
                {
                    var add = await control.AddUserAsync(username, password, role, phoneNumber, Email);
                    MessageBox.Show(add, "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    await auditLogsController.AddAuditLogs((await control.GetAllUsersAsync()).Find(x => x.Username == username).Id, $"Added {role} ({username}) by Admin: {form.GetUser.Username}", $"Added user: {username}");
                }
                catch (ArgumentException x)
                {
                    MessageBox.Show(x.Message, "Problem has been reached!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               
            }
            else
            {
                 username = listBox1.SelectedIndex.ToString();
                try
                {
                    var get = (await control.GetAllUsersAsync()).Find(x => x.Username == username).Id;
                    var add = await control.UpdateUserAsync(get,username, password, role, phoneNumber, Email);
                    MessageBox.Show(add, "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  

                    await auditLogsController.AddAuditLogs((await control.GetAllUsersAsync()).Find(x => x.Username == username).Id, $"Added {role} by Admin: {form.GetUser.Username}", DateTime.Now.ToString());
                }
                catch (ArgumentException x)
                {

                    MessageBox.Show(x.Message, "Problem has been reached!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                await auditLogsController.AddAuditLogs((await control.GetAllUsersAsync()).Find(x => x.Username == username).Id, $"Updated {role} ({username}) by Admin: {form.GetUser.Username}", $"Updated user: {username}");
            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminCommandView admin = new();
            admin.ShowDialog();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private CancellationTokenSource _cts;

        private async void textBox6_TextChanged(object sender, EventArgs e)
        {
            _cts?.Cancel();

            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token);
                UsersCotroller userControl = new();

                var users = await userControl
                    .GetUserSuggestionsAsync(textBox6.Text);
                listBox1.DataSource = null;
                listBox1.DataSource = users;
                listBox1.DisplayMember = "Name";
            }
            catch (TaskCanceledException)
            {
                // User typed another character before 300ms elapsed
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem is User user)
            {
                textBox1.Text = user.Username;
                textBox4.Text = user.Email;
                textBox5.Text = user.PhoneNumber;
                if (user.Role == RoleType.Employee)
                {
                    radioButton2 .Checked = true;
                }
                else radioButton1.Checked = true;
            }
        }
    }
}
