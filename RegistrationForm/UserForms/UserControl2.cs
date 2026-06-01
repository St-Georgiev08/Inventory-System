using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class UserControl2 : UserControl
    {
        private ProductDetails products { get; set; }
        public string Getreason { set; get; }
        private User GetUser { set; get; }
        public UserControl2(User user)
        {
            InitializeComponent();
            GetUser = user;
        }
        public async void LoadProduct(ProductDetails product)
        {
            lblName.Text = product.Products.Name;
            lblCategory.Text = product.Products.Category.Name;
            lblPrice.Text = $"{product.Products.Price} euro";
            products = product;
            pictureBox1.Image = Image.FromFile(product.ImagePath);
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            ViewAllProducts Products = new ViewAllProducts(GetUser);
            Getreason = "control2";
            Add_Update_Products add_product = new Add_Update_Products(Getreason, GetUser);
            add_product.Hide();
            add_product.ShowDialog();
            
            Products.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ProductDetailsController controller = new ProductDetailsController();
            ProductsController controller2 = new ProductsController();
            try
            {
                MessageBox.Show(await controller.DeleteProductDetails(products.Id), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
