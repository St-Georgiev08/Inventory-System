using Inventory_System.Entities;
using RegistrationForm.EmployeeViewsFolder;
using SalesSystem.Business.Controllers;
using SalesSystem.Business.DTOs;
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
    public partial class Add_Update_Categories : Form
    {
        private  User GetUser {  get; set; }
        public Add_Update_Categories(User user)
        {
            InitializeComponent();
            GetUser = user;
        }
        private bool update = false;
        private CategoriesController categoriesController = new();
        private async void button1_Click(object sender, EventArgs e)
        {
            var list = await categoriesController.GetAllCategories();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Name";
            button2.Text = "Update product";
            comboBox1.Visible = true;
            label2.Visible = true;
            update = true;
            label5.Visible = false;
                richTextBox1.Visible = false;
        }
        private AuditLogsController auditsLogController = new();
        private async void button2_Click(object sender, EventArgs e)
        {
            string name = "";
            string? desc = "";
            if (update)
            {
                name = textBox1.Text;
                name = textBox2.Text;
                try
                {
                    var find = (await categoriesController.GetAllCategories()).FirstOrDefault(x => x.Name == name);
                    MessageBox.Show(await categoriesController.UpdateCategory(find.Id, name, desc), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await auditsLogController.AddAuditLogs(GetUser.Id, $"Updated category ({name}) by Employee: {GetUser.Username}", $"Updated category: {name}");
                }
                catch (ArgumentException x)
                {

                    MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            name = textBox1.Text;
            desc = textBox2.Text;
            try
            {

                MessageBox.Show(await categoriesController.AddCategory(name, desc), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               await auditsLogController.AddAuditLogs(GetUser.Id, $"Added category ({name}) by Employee: {GetUser.Username}", $"Added category: {name}");
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = (await categoriesController.GetAllCategories()).Find(x => x.Name == comboBox1.SelectedValue);
            if (m == null)
            {
                MessageBox.Show("Problem reached!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = m.Name;
            textBox2.Text = m.Description;
        }

        private async void Add_Update_Categories_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label2.Visible = false;
            label5.Visible = true;
            richTextBox1.Visible = true;
            update = false;
            var list = await categoriesController.GetAllCategories();
            richTextBox1.Text = string.Join(Environment.NewLine, list.Select(x => x.Name));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView view = new(GetUser);
            view.ShowDialog();
            this.Close();
        }
    }
}
