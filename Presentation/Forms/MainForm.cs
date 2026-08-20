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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // MainForm properties
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = $"Smart Warehouse Management System (SWMS) - User: {_currentUser?.FullName} [{_currentUser?.RoleName}]";

            this.ResumeLayout(false);
        }

        private void SetupUserSession()
        {
            // Apply role-based permissions to menu/buttons here if needed
        }

        private void MenuProducts_Click(object sender, EventArgs e)
        {
            // Open ProductsForm
            // ProductsForm frm = new ProductsForm();
            // frm.ShowDialog();
        }

        private void MenuWarehouses_Click(object sender, EventArgs e)
        {
            // Open WarehousesForm
        }
    }
}
