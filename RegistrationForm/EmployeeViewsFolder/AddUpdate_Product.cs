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
    public partial class AddUpdate_Product : Form
    {
        public AddUpdate_Product()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeCommandsView employeeCommandsView = new();
            employeeCommandsView.ShowDialog();

        }
    }
}
