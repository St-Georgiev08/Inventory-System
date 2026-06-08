using ClosedXML.Excel;
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
    public partial class ShowAllOrders : Form
    {
        private User GetUser { set; get; }
        public ShowAllOrders(User user)
        {
            InitializeComponent();
            GetUser = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private readonly OrderItemsController productsController = new();
        private readonly BindingSource _productsSource = new();
        private async Task LoadOrdersAsync(List<OrderGridDto> dtso)
        {

            try
            {

                _productsSource.DataSource = dtso;
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
        private async void button1_Click_1(object sender, EventArgs e)
        {
            //string daqteFrom = textBox1.Text;
            //string dateTo = textBox2.Text;
            //DateTime To;
            //DateTime From;
            //bool successfullyParsedTo = DateTime.TryParse(dateTo, out To);
            //bool successfullyParsedFrom = DateTime.TryParse(daqteFrom, out From);
            //if (successfullyParsedFrom == false || successfullyParsedTo == false)
            //{
            //    MessageBox.Show("Invalid date format! Follow the instructions above the text boxes.", "Problem has been reached!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //await LoadOrdersAsync();

            string daqteFrom = textBox1.Text;
            string dateTo = textBox2.Text;
            DateTime To;
            DateTime From;
            List<OrderGridDto> list = await productsController.GetForGrid();
            if (checkBox1.Checked == true)
            {
                To = dateTimePicker2.Value;
                From = dateTimePicker1.Value;
            }
            else
            {

                bool successfullyParsedTo = DateTime.TryParse(dateTo, out To);
                bool successfullyParsedFrom = DateTime.TryParse(daqteFrom, out From);

                if (successfullyParsedFrom == false || successfullyParsedTo == false || From >= To || From == To)
                {
                    MessageBox.Show("Invalid date format! Follow the instructions above the text boxes.", "Problem has been reached!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                list = list.Where(x => x.OrderedOn >= From && x.OrderedOn <= To).ToList();
                await LoadOrdersAsync(list);
            }
            list = list.Where(x => x.OrderedOn >= From.Date && x.OrderedOn <= To.Date).ToList();
            await LoadOrdersAsync(list);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView view = new EmployeeCommandsView(GetUser);
            view.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeCommandsView view = new EmployeeCommandsView(GetUser);
            view.ShowDialog();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label4.Text = "Please two different dates! <From> date must be older than <To> date.";

            }
            else
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label4.Text = "Corect format(YYYY / MM / DD hh: mm:ss)";
            }
        }

        private void ShowAllOrders_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            _productsSource.DataSource = null;
            dataGridView1.DataSource = _productsSource;
        }
    }
}
