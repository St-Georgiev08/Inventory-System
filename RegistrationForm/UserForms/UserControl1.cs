using Inventory_System.Entities;
using SalesSystem.Business.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.UserForms
{
    public partial class UserControl1 : UserControl
    {
        private ProductDetails products { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }
        public async Task LoadProduct(ProductDetails product)
        {
            lblName.Text = product.Products?.Name ?? "Unknown";
            lblCategory.Text = product.Products?.Category?.Name ?? "Uncategorized";
            lblPrice.Text = product.Products != null ? $"{product.Products.Price} euro" : "Price unavailable";  

            products = product;

            string imagePath = Path.Combine(
                Application.StartupPath,
                "ProductImages",
                product.ImagePath);

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private readonly AuditLogsController logs = new();
        private async void button1_Click_1(object sender, EventArgs e)
        {
            OrdersController orders = new();
            OrderItemsController items = new();
            int num = Convert.ToInt16(numericUpDown1.Value);
            if (num > 0)
            {
                MessageBox.Show("You cannot order 0 items. Pick a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                await orders.Add($"Order for: {products.Products.Name}", DateTime.Now, products.Products.Price * num);
                var get = (await orders.GetAll()).Last().Id;
                MessageBox.Show(await items.AddOrder(get, products.Products.Id, num, products.Products.Price), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await logs.AddAuditLogs(get, $"Added order for: {products.Products.Name} with quantity: {num}", $"Added order for: {products.Products.Name}");
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UserControl1_Load(object sender, EventArgs e)
        {

        }

    }
}
