using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WarehouseManagement.BusinessLogic;

namespace WarehouseManagement.Presentation.Forms
{
    public partial class ProductsForm : KryptonForm
    {
        private readonly ProductService _productService;

        public ProductsForm()
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "خطأ في تحميل المنتجات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KryptonMessageBox.Show("سيتم فتح شاشة إضافة منتج جديد.", "إضافة منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
