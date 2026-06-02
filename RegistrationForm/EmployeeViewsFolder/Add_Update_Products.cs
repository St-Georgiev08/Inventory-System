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
        private readonly ProductDetails product = new();
        public ProductDetails details { get; set; }
        public string ReasonForUsing { get; set; }
        private User GetUser { set; get; }
        public Add_Update_Products(string reason, User getUser  )
        {
            InitializeComponent();
            ReasonForUsing = reason;
            GetUser = getUser;
        }
        private async Task LoadCategories()
        {
            comboBox1.DataSource = await categoriesController.GetAllCategories();
            comboBox1.DisplayMember = "Name"; // Assuming the Categories class has a Name property
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeCommandsView view = new(GetUser);
            view.ShowDialog();
            this.Close();

        }
        private string? _selectedImagePath;
        private async void button3_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();

            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagesFolder =
                    Path.Combine(Application.StartupPath, "Images");

                Directory.CreateDirectory(imagesFolder);

                string fileName =
                    $"{Guid.NewGuid()}{Path.GetExtension(openFileDialog.FileName)}";

                string destinationPath =
                    Path.Combine(imagesFolder, fileName);

                File.Copy(openFileDialog.FileName, destinationPath, true);

                _selectedImagePath = destinationPath;

                pictureBox1.Image = Image.FromFile(destinationPath);
            }
        }
        private readonly ProductsController productsController = new ProductsController();
        private readonly ProductDetailsController productDetailsController = new ProductDetailsController();
        private readonly AuditLogsController auditLogsController = new AuditLogsController();
        private async void button2_Click(object sender, EventArgs e)
        {

            if(ReasonForUsing != "control2")
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

                    File.Copy(_selectedImagePath, destinationPath,true);
                    var selectedCategory = (Categories)comboBox1.SelectedItem;
                    if (decimal.TryParse(textBox2.Text, out decimal value) && int.TryParse(textBox1.Text, out int qantity))
                    {
                        MessageBox.Show(await productsController.AddProduct(textBox3.Text, value, qantity, selectedCategory.Id), "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await productDetailsController.AddProductDetails((await productsController.GetAllProduct()).Last().Id,richTextBox1.Text, destinationPath, GetUser.Id);
                        await auditLogsController.AddAuditLogs((await productsController.GetAllProduct()).Last().Id, $"Added product: {textBox3.Text} by Employee: {GetUser.Username}", $"Added product: {textBox3.Text}");
                   
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
            else
            {
                
                try
                {
                    string imagesFolder =
                    Path.Combine(Application.StartupPath, "ProductImages");

                    Directory.CreateDirectory(imagesFolder);

                    string newfile =
                        Guid.NewGuid().ToString() +
                        Path.GetExtension(_selectedImagePath);

                    string NewDestinationPath =
                        Path.Combine(imagesFolder, newfile);

                    File.Copy(_selectedImagePath, NewDestinationPath,true);
                    var selectedCategory = (Categories)comboBox1.SelectedItem;
                    var products =(await productsController.GetAllProduct()).First(x=>x.Name == details.Products.Name);
                    var detail = (await productDetailsController.GetAll()).First(x => x.Products.Id == products.Id);
                    if (decimal.TryParse(textBox2.Text, out decimal value) && int.TryParse(textBox1.Text, out int qantity))
                    {
                        MessageBox.Show(await productsController.UpdateProduct(products.Id,textBox3.Text, value, qantity, selectedCategory.Id), "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await productDetailsController.UpdateProductDetails(detail.Id,products.Id,richTextBox1.Text, NewDestinationPath, GetUser.Id);
                        await auditLogsController.AddAuditLogs(products.Id, $"Updated product: {textBox3.Text} by Employee: {GetUser.Username}", $"Updated product: {textBox3.Text}");
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

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = null;
        }

        private async void Add_Update_Products_Load(object sender, EventArgs e)
        {
           await LoadCategories();
            if(ReasonForUsing == "control2")
            {
                //EmployeeCommandsView.ReasonForUsing = "";
                textBox3.Text = details.Products.Name;
                textBox2.Text = details.Products.Price.ToString();
                textBox1.Text = details.Products.Quantity.ToString();
                comboBox1.SelectedValue = details.Products.Category.Name;
                richTextBox1.Text = details.Description.ToString();
                string fullPath = Path.Combine(
                Application.StartupPath,
                 "ProductImages",
                 product.ImagePath);

                if (File.Exists(fullPath))
                {
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
                button2.Text = "Update";
                
                button3.Text = "update from your device";
            }
            else
            {
                pictureBox1.Image = null;
                button2.Text = "Add new product:";
                button3.Text = "Add from your device";
            }
            
        }
    }
}
