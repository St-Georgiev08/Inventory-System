
using Inventory_System.Entities;
using RegistrationForm.ClientViewsFolder;
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
    public partial class ClientMainForm : Form
    {
        private User User { set; get; }
        public ClientMainForm(User user)
        {
            InitializeComponent();
            User = user;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllClintsOrders all = new AllClintsOrders();
            all.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateClientForm updateClientForm = new UpdateClientForm(User);
            updateClientForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShopItems all = new ShopItems(User);
            all.ShowDialog();
            this.Close();
        }

        private void ClientMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
