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
    public partial class UserControl4 : UserControl
    {
        private ProductDetails products { get; set; }
        public UserControl4()
        {
            InitializeComponent();
        }
        public async void LoadProduct(ProductDetails product)
        {
            lblName.Text = product.Products.Name;
            lblCategory.Text = product.Products.Category.Name;
            lblPrice.Text = $"{product.Products.Price} euro";

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
        private async void button1_Click(object sender, EventArgs e)
        {
            OrdersController orders = new();
            OrderItemsController items = new();
            try
            {
                var get = (await orders.GetAll()).Last().Id;
                MessageBox.Show(await items.DeleteOrderItem(get, products.Id), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
