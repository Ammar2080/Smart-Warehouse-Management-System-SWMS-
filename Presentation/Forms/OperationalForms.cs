using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WarehouseManagement.BusinessLogic;

namespace WarehouseManagement.Presentation.Forms
{
    public partial class ProductsForm : KryptonForm
    {
        private readonly ProductService _productService = new ProductService();

        public ProductsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Name = "ProductsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Smart Warehouse - Products Management";
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            try
            {
                var products = _productService.GetAllProducts();
                // Bind to DataGridView or UI controls
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public partial class InventoryForm : KryptonForm
    {
        private readonly InventoryService _inventoryService = new InventoryService();

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Name = "InventoryForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Smart Warehouse - Inventory & Stock Tracking";
            this.ResumeLayout(false);
        }
    }
}
