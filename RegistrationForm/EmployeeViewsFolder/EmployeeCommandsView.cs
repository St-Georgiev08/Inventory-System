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
    public partial class EmployeeCommandsView : Form
    {
        public string ReasonForUsing {  get; set; }
        public EmployeeCommandsView()
        {
            InitializeComponent();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 form1 = new RegistrationForm1();
            form1.ShowDialog();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReasonForUsing = "Add";
            Add_Update_Products addUpdate_Product = new();
            addUpdate_Product.ShowDialog();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewMyClientsOrders viewMyClientsOrders = new();
            viewMyClientsOrders.ShowDialog();
            this.Close();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReasonForUsing = "Update";
            Add_Update_Products addUpdate_Product = new();
            addUpdate_Product.ShowDialog();
            this.Close();
        }
    }
}
