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

namespace RegistrationForm.EmployeeViewsFolder
{
    public partial class ViewAllProducts : Form
    {
        private User GetUser { set; get; }
        public ViewAllProducts(User user)
        {
            InitializeComponent();
            GetUser = user;
        }
        private async Task LoadProducts(List<ProductDetails> products)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var product in products)
            {
                UserControl2 card = new UserControl2(GetUser);

                card.LoadProduct(product);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private async void ShopItems_Load()
        {
            ProductDetailsCRUD productService = new();
            var products = await productService.GetAll();
            await LoadProducts(products);
        }
        public async void button2_Click(object sender, EventArgs e)
        {

            ShopItems_Load();
            ProductDetailsController product = new();
            string searchTerm = textBox1.Text;
            bool name = radioButton1.Checked;
            bool price = radioButton2.Checked;
            bool desc = checkBox1.Checked;
            string type = comboBox1.SelectedText;
            // use the public property
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var products = await product.FindAllWith(searchTerm);


                var filter = await product.SortByType(products, name, price, desc, type);
                await LoadProducts(filter);
            }
            else
            {
                var filter = await product.SortByType(await product.GetAll(), name, price, desc, type);
                await LoadProducts(filter);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView employeeCommandsView = new (GetUser);
            employeeCommandsView.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            EmployeeCommandsView employeeCommandsView = new(GetUser);
            employeeCommandsView.ShowDialog();
            this.Close();
        }
    }
}
