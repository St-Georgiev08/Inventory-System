using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.ClientViewsFolder
{
    public partial class AllClintsOrders : Form
    {
        public AllClintsOrders()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            ShopItems shopItems = new();
            shopItems.ShowDialog();
        }
    }
}
