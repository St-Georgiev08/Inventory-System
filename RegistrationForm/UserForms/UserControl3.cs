using Inventory_System.Entities;
using RegistrationForm.EmployeeViewsFolder;
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
    public partial class UserControl3 : UserControl
    {
        private ProductDetails products { get; set; }
        private User GetUser { set; get; }
        public UserControl3(ProductDetails product, User user)
        {
            InitializeComponent();
            products = product;
            GetUser = user;
            LoadProduct(product);
        }
        public async void LoadProduct(ProductDetails product)
        {
            lblName.Text = product.Products?.Name ?? "Unknown";
            lblCategory.Text = product.Products?.Category?.Name ?? "Uncategorized";
            lblPrice.Text = product.Products != null ? $"{product.Products.Price} €" : "Price unavailable";

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
                MessageBox.Show(await items.DeleteOrderItem(get, products.Id, null), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private async void button2_Click(object sender, EventArgs e)
        {
               ViewAllProducts view = new ViewAllProducts(GetUser);
             this.Hide();
            Add_Update_Products add = new Add_Update_Products("control2", GetUser, products);
               add.ShowDialog();
               view.Close();

        }
    }
}
