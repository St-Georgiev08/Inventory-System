using RegistrationForm.EmployeeViewsFolder;
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
    public partial class Add_Update_Categories : Form
    {
        public Add_Update_Categories()
        {
            InitializeComponent();
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
        }

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

        private void Add_Update_Categories_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label2.Visible = false;
            update = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView view = new();
            view.ShowDialog();
            this.Close();
        }
    }
}
