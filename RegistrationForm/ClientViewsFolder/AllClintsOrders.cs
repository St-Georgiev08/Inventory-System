using Inventory_System.Entities;
using RegistrationForm.UserForms;
using SalesSystem.Data.Controllers;
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

        private async void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            ShopItems shopItems = new();
            shopItems.ShowDialog();
        }

        private async void LoadProduct(List<ProductDetails> products)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var product in products)
            {
                UserControl4 card = new();

                card.LoadProduct(product);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private readonly OrderItemsController orders = new();
        private async void AllClintsOrders_Load(object sender, EventArgs e)
        {
            RegistrationForm1 form1 = new RegistrationForm1();
            var user = form1.GetUser;
            var list = await orders.GetOrderedProductDetailsByUserAsync(user.Id);
            LoadProduct(list);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ShopItems items = new();
            items.ShowDialog(); this.Close();
        }
    }
}
