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

namespace RegistrationForm
{
    public partial class Add_Update_Products : Form
    {
        private readonly CategoriesController categoriesController = new();
        public Add_Update_Products()
        {
            InitializeComponent();
        }
        private async Task LoadCategories()
        {
            comboBox1.DataSource = await categoriesController.GetAllCategories();
            comboBox1.DisplayMember = "Name"; // Assuming the Categories class has a Name property
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeCommandsView view = new();
            view.ShowDialog();

        }
        private string? _selectedImagePath;
        private async void button3_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();

            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog.FileName;

                using (var bmp = new Bitmap(_selectedImagePath))
                {
                    pictureBox1.Image = new Bitmap(bmp);
                }
            }


        }
        private readonly ProductsController productsController = new ProductsController();
        private readonly ProductDetailsController productDetailsController = new ProductDetailsController();
        private async void button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(_selectedImagePath))
            {
                MessageBox.Show(
                    "Please select an image first.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            try
            {
                string imagesFolder =
                Path.Combine(Application.StartupPath, "ProductImages");

                Directory.CreateDirectory(imagesFolder);

                string fileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(_selectedImagePath);

                string destinationPath =
                    Path.Combine(imagesFolder, fileName);   

                File.Copy(_selectedImagePath, destinationPath);
                var selectedCategory = (Categories)comboBox1.SelectedItem;
                if (decimal.TryParse(textBox2.Text, out decimal value) && int.TryParse(textBox3.Text, out int qantity))
                {
                    MessageBox.Show(await productsController.AddProduct(textBox1.Text, value, qantity, selectedCategory.Id), "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await productDetailsController.AddProductDetails(richTextBox1.Text,fileName);
                }  
                else
                {
                    MessageBox.Show("Wrong input for qantity or price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void Add_Update_Products_Load(object sender, EventArgs e)
        {
           await LoadCategories();
        }
    }
}
