using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WarehouseManagement.Models;

namespace WarehouseManagement.Presentation.Forms
{
    public partial class MainForm : KryptonForm
    {
        private readonly User _currentUser;

        public MainForm(User currentUser)
        {
            _currentUser = currentUser ?? new User { FullName = "مدير النظام", RoleName = "Admin" };
            InitializeComponent();
            ApplyProfessionalTheme();
        }

        private void ApplyProfessionalTheme()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = $"نظام إدارة المستودعات الذكي (SWMS) - المستخدم الحالي: {_currentUser.FullName} [{_currentUser.RoleName}]";
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm frm = new ProductsForm();
            frm.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm frm = new InventoryForm();
            frm.ShowDialog();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            StockInForm frm = new StockInForm();
            frm.ShowDialog();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            StockOutForm frm = new StockOutForm();
            frm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm frm = new SuppliersForm();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm frm = new CustomersForm();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm frm = new ReportsForm();
            frm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm frm = new SettingsForm();
            frm.ShowDialog();
        }
    }
}
