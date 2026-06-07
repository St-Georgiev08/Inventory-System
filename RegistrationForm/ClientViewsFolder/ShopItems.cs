using Inventory_System.Entities;
using RegistrationForm.ClientViewsFolder;
using RegistrationForm.UserForms;
using SalesSystem.Business.Controllers;
using SalesSystem.Business.Servises;
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
        }

        private async void OnLoad()
        {
            
        }

        private async Task LoadCategories()
        {
            comboBox1.DataSource = await categories.GetAllCategories();
            comboBox1.DisplayMember = "Name"; // Assuming the Categories class has a Name property
        }

        ProductDetailsCRUD productService = new();

        // Correct event-handler signature so the Designer's Load wiring works
        private async void ShopItems_Load(object sender, EventArgs e)
        {
            try
            {
                label3.Text = $"Wellcome, {getRole.Username}";
                await LoadCategories();
                var products = await productService.GetAll();
                await LoadProducts(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load shop items: {ex.Message}", "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
        }
        private async Task LoadProducts(List<ProductDetails> products)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var product in products)
            {
                UserControl1 card = new UserControl1();

               await card.LoadProduct(product);

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ProductDetailsController product = new();
            string searchTerm = textBox1.Text;
            bool name = radioButton1.Checked;
            bool price = radioButton2.Checked;
            bool desc = checkBox1.Checked;
            string type = (comboBox1.SelectedItem as Categories)?.Name ?? string.Empty;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllClintsOrders allClints = new(getRole);
            allClints.ShowDialog();
            this.Close();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm1 form1 = new(getRole);
            form1.ShowDialog();
            this.Close();

        }
    }
}
