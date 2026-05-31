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
        public ViewMyClientsOrders()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeCommandsView employeeCommandsView = new();
            employeeCommandsView.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

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
                await LoadOrdersAsync(Name, desc);
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
    }
}
