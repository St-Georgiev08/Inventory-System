using Inventory_System.Entities;
using RegistrationForm.UserForms;
using SalesSystem.Data.Controllers;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace RegistrationForm
{
    public partial class ShopItems : Form
    {
        public ShopItems()
        {
            InitializeComponent();
            ShopItems_Load();
        }
        private async void ShopItems_Load()
        {
            ProductDetailsCRUD productService = new();
            var products = await productService.GetAll();
            LoadProducts(products);
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
        }
        private async void LoadProducts(List<ProductDetails> products)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var product in products)
            {
                UserControl1 card = new UserControl1();

                card.LoadProduct(product);

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ShopItems_Load();
            ProductDetailsController product = new();
                var products = await product.FindAllWith(textBox1.Text);
            bool m = false;
            bool n = false;
            if (this.radioButton1.Checked)
            {
                n = true;
            }
            else
            {
                m = true;
            }
            var filter = await product.SortByType(products, n, m);
               LoadProducts(filter);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
            
        }
    }
}
