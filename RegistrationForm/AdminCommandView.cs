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
    }
}
