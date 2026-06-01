using Inventory_System.Entities;
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
        private string ReasonForUsing { get; set; }
        private User GetUser { set; get; }
        public EmployeeCommandsView(User user)
        {
            InitializeComponent();
            GetUser = user;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 form1 = new RegistrationForm1(GetUser);
            form1.ShowDialog();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReasonForUsing = "Add";
            Add_Update_Products addUpdate_Product = new(ReasonForUsing, GetUser);
            addUpdate_Product.ShowDialog();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewMyClientsOrders viewMyClientsOrders = new(GetUser);
            viewMyClientsOrders.ShowDialog();
            this.Close();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReasonForUsing = "Update";
            Add_Update_Products addUpdate_Product = new(ReasonForUsing, GetUser);
            addUpdate_Product.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewMyClientsOrders viewMyClientsOrders = new(GetUser);
            viewMyClientsOrders.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Update_Categories addUpdate_Categories = new(GetUser);
            addUpdate_Categories.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
