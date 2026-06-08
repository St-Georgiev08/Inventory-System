using ClosedXML.Excel;
using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Business.Controllers;
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
    public partial class SeeAllEmployees : Form
    {
        public User GetUser { set; get; }
        public SeeAllEmployees(User user)
        {
            InitializeComponent();
            GetUser = user;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            AdminCommandView admin = new(GetUser);
            admin.ShowDialog(); this.Close();
        }
        private readonly UsersCotroller productsController = new();
        private readonly BindingSource _productsSource = new();
        private async Task LoadOrdersAsync(bool name, bool desc, string? find)
        {

            try
            {
                var list = await productsController.GetDataGrid(name, desc, find);
                _productsSource.DataSource = list;
                dataGridView1.DataSource = _productsSource;
                dataGridView1.Columns[0].Visible = false;
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
        private async Task ExportToExcelAsync()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Products";
            saveFileDialog.FileName = "Products.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                await Task.Run(() =>
                {
                    using XLWorkbook workbook = new XLWorkbook();

                    var worksheet = workbook.Worksheets.Add("Orders log");

                    // Headers
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value =
                            dataGridView1.Columns[col].HeaderText;
                    }

                    // Data
                    for (int row = 0; row < dataGridView1.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataGridView1.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value =
                                dataGridView1.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(saveFileDialog.FileName);
                });

                MessageBox.Show(
                    "Export completed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Export Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string find = textBox1.Text;
            bool Name = radioButton1.Checked;
            bool desc = radioButton2.Checked;
            //if (!Name && !desc)
            //{
            //    MessageBox.Show("You must pick how the list would be sorted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            UserControl user = new();
            try
            {
                await LoadOrdersAsync(Name, desc,find);
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

        private void SeeAllEmployees_Load(object sender, EventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
