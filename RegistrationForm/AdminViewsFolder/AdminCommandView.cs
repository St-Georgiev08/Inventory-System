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
        public AdminCommandView()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 registrationForm1 = new RegistrationForm1();
            registrationForm1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminAddsRoles adminAddsRoles = new AdminAddsRoles();
            GetReasonForClick = "Add";
            adminAddsRoles.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminAddsRoles adminCommandView = new();
            GetReasonForClick = "Update";
            adminCommandView.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            EventLogForm eventLogForm = new EventLogForm();
            eventLogForm.ShowDialog();
        }
    }
}
