using Inventory_System.Entities;
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

namespace RegistrationForm.EmployeeViewsFolder
{
    public partial class ViewMyClientsOrders : Form
    {
        private User GetUser { set; get; }
        public ViewMyClientsOrders(User user)
        {
            InitializeComponent();
            GetUser = user;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
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
        private readonly OrderItemsController orderItems = new();
        private int _selectedClientId;
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dataGridView1.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                    _selectedClientId = Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                    dataGridView1.Visible = false;
                    dataGridView2.Visible = true;

                    await LoadEmployeeDatagrid(_selectedClientId);

                    return;
                
            }
        }
        private readonly ProductsController productsControllerr = new();
        private async void dataGridView2_CellContentClick(
      object sender,
      DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                int orderId = Convert.ToInt32(
                    dataGridView2.Rows[e.RowIndex]
                    .Cells["OrderId"].Value);

                int productId = Convert.ToInt32(
                    dataGridView2.Rows[e.RowIndex]
                    .Cells["ProductId"].Value);

                var result = await orderItems.DeleteOrderItem(
                    orderId,
                    productId,
                    "Finished");

                MessageBox.Show(result);

                await LoadEmployeeDatagrid(_selectedClientId);
            }
        }
        private async Task LoadEmployeeDatagrid(int userId)
        {
            try
            {
                dataGridView2.Columns.Clear();

                dataGridView2.DataSource =
                    await orderItems.GetForGridOrders(userId);

                if (!dataGridView2.Columns.Contains("btnDelete"))
                {
                    DataGridViewButtonColumn btnColumn =
                        new DataGridViewButtonColumn();

                    btnColumn.Name = "btnDelete";
                    btnColumn.HeaderText = "Actions";
                    btnColumn.Text = "Finish Order";
                    btnColumn.UseColumnTextForButtonValue = true;

                    dataGridView2.Columns.Add(btnColumn);
                }

                dataGridView2.Columns["OrderId"].Visible = false;
                dataGridView2.Columns["ProductId"].Visible = false;
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
        private async Task LoadClientsAsync()
        {

            try
            {
                var list = await productsController.GetDataGridClients(radioButton1.Checked, radioButton2.Checked);
                if (textBox1.Text != "")
                {
                    list = list.Where(x => x.Name.Contains(textBox1.Text) || x.Email.Contains(textBox1.Text)).ToList();
                }

                dataGridView1.Columns.Clear();
                _productsSource.DataSource = list;
                dataGridView1.DataSource = _productsSource;

                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();

                btnColumn.Name = "btnEdit";
                btnColumn.HeaderText = "show all products";
                btnColumn.Text = "Show product";
                btnColumn.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(btnColumn);
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
            //string find = textBox1.Text;
            //bool Name = radioButton1.Checked;
            //bool desc = radioButton2.Checked;
            //if (!Name && !desc)
            //{
            //    MessageBox.Show("You must pick how the list would be sorted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

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

        private void ViewMyClientsOrders_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dataGridView1.DataSource = null;
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
        }
    }
}
