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

namespace RegistrationForm
{
    public partial class AdminCommandView : Form
    {
        public string GetReasonForClick { get; set; }
        private User getRole { set; get; }
        public AdminCommandView(User user)
        {
            InitializeComponent();
            getRole = user;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 registrationForm1 = new RegistrationForm1(getRole);
            registrationForm1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GetReasonForClick = "Add";
            AdminAddsRoles adminAddsRoles = new AdminAddsRoles(getRole,GetReasonForClick);
            adminAddsRoles.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GetReasonForClick = "Update";
            AdminAddsRoles adminCommandView = new(getRole,GetReasonForClick);
            adminCommandView.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventLogForm eventLogForm = new EventLogForm(getRole);
            eventLogForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeeAllOrders see = new(getRole);
            see.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeeAllEmployees see = new(getRole);
            see.ShowDialog();
            this.Close();
        }

        private void AdminCommandView_Load(object sender, EventArgs e)
        {

        }
    }
}
