using System;
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
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            InitializeComponent();
            SetupUserSession();
        }

        private void SetupUserSession()
        {
            this.Text = $"Smart Warehouse Management System (SWMS) - User: {_currentUser?.FullName} [{_currentUser?.RoleName}]";
        }

        private void MenuProducts_Click(object sender, EventArgs e)
        {
            ProductsForm frm = new ProductsForm();
            frm.ShowDialog();
        }
    }
}
