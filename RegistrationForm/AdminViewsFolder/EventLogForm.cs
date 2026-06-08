using ClosedXML.Excel;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Inventory_System;
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
namespace RegistrationForm
{
    public partial class EventLogForm : Form
    {
        public User GetUser { set; get; }
        public EventLogForm(User user)
        {
            InitializeComponent();
            GetUser = user;
        }
        private readonly AuditLogsController auditLogsController = new();
        private readonly BindingSource _productsSource = new();
        private async Task LoadAuditsAsync(List<AuditsLogDto> dtos)
        {

            try
            {


                _productsSource.DataSource = dtos;
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


        //Exporter
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

                    var worksheet = workbook.Worksheets.Add("Event log");

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
        private async void Form1_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
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
            //await LoadAuditsAsync();

            string daqteFrom = textBox1.Text;
            string dateTo = textBox2.Text;
            DateTime To;
            DateTime From;
            List<AuditsLogDto> list = await auditLogsController.GetForGrid();
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

                list = list.Where(x => x.Time >= From.Date && x.Time <= To.Date).ToList();
                await LoadAuditsAsync(list);
            }
            list = list.Where(x => x.Time.Date >= From.Date && x.Time.Date <= To.Date).ToList();
            await LoadAuditsAsync(list);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCommandView view = new(GetUser);
            view.ShowDialog();
            this.Close();
        }

        private void EventLogForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            _productsSource.DataSource = null;
            dataGridView1.DataSource = _productsSource;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
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
    }
}
