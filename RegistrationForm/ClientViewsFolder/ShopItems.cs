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
        private readonly CategoriesController categories;
        private User getRole { set; get; }
        public ShopItems(User user)
        {
            categories = new();
            getRole = user;
            InitializeComponent();
            ShopItems_Load();
            OnLoad();
        }

        private async void OnLoad()
        {
            label3.Text = $"Wellcome, {getRole.Username}";
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            comboBox1.DataSource = await categories.GetAllCategories();
            comboBox1.DisplayMember = "Name"; // Assuming the Categories class has a Name property
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
            string searchTerm = textBox1.Text;
            bool name = radioButton1.Checked;
            bool price = radioButton2.Checked;
            bool desc = checkBox1.Checked;
            string type = comboBox1.SelectedText;
            // use the public property
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var products = await product.FindAllWith(searchTerm);


                var filter = await product.SortByType(products, name,price,desc,type);
                LoadProducts(filter);
            }
            else
            {
                var filter = await product.SortByType(await product.GetAll(), name, price, desc, type);
                LoadProducts(filter);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ClientMainForm clientMainForm = new(getRole);
            clientMainForm.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
