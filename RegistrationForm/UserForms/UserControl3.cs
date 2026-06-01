using Inventory_System.Entities;
using RegistrationForm.EmployeeViewsFolder;
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
            lblName.Text = product.Products.Name;
            lblCategory.Text = product.Products.Category.Name;
            lblPrice.Text = $"{product.Products.Price} euro";
            products = product;
            pictureBox1.Image = Image.FromFile(product.ImagePath);
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
       
        private async void button2_Click(object sender, EventArgs e)
        {
               ViewAllProducts view = new ViewAllProducts(GetUser);
               
               Add_Update_Products add = new Add_Update_Products("control2", GetUser);
               add.details = products;
               add.ShowDialog();
               view.Close();

        }
    }
}
