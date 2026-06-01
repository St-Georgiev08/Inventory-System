using Inventory_System.Entities;

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

namespace RegistrationForm.EmployeeViewsFolder
{
    public partial class ViewMyClientsOrders : Form
    {
        private User GetUser { set; get; }   
        public ViewMyClientsOrders(User user)
        {
            InitializeComponent();
            GetUser = user;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeCommandsView employeeCommandsView = new(GetUser);
            employeeCommandsView.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private readonly UsersCotroller productsController = new();
        private readonly BindingSource _productsSource = new();
        private async Task LoadClientsAsync()
        {

            try
            {
                var list = await productsController.GetDataGridClients(radioButton1.Checked, radioButton2.Checked);
                _productsSource.DataSource = list;
                dataGridView1.DataSource = _productsSource;
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Problem has been reached!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unexpected error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string find = textBox1.Text;
            bool Name = radioButton1.Checked;
            bool desc = radioButton2.Checked;
            if (!Name && !desc)
            {
                MessageBox.Show("You must pick how the list would be sorted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UserControl user = new();
            try
            {
                await LoadClientsAsync();
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(
                    x.Message,
                    "Sorting Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView view = new EmployeeCommandsView(GetUser);
            
            view.ShowDialog();
            this.Close();
        }
    }
}
