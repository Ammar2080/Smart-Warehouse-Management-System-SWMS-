using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WarehouseManagement.Presentation.Forms
{
    public partial class DashboardForm : KryptonForm { public DashboardForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Dashboard"; } }
    public partial class ProductDetailsForm : KryptonForm { public ProductDetailsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Product Details"; } }
    public partial class CategoriesForm : KryptonForm { public CategoriesForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Categories Management"; } }
    public partial class UnitsForm : KryptonForm { public UnitsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Units Management"; } }
    public partial class SuppliersForm : KryptonForm { public SuppliersForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Suppliers Management"; } }
    public partial class CustomersForm : KryptonForm { public CustomersForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Customers Management"; } }
    public partial class WarehousesForm : KryptonForm { public WarehousesForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Warehouses Management"; } }
    public partial class StockInForm : KryptonForm { public StockInForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Stock In (Purchases)"; } }
    public partial class StockOutForm : KryptonForm { public StockOutForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Stock Out (Sales)"; } }
    public partial class StockTransferForm : KryptonForm { public StockTransferForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Stock Transfer"; } }
    public partial class StockAdjustmentForm : KryptonForm { public StockAdjustmentForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Stock Adjustment"; } }
    public partial class LowStockForm : KryptonForm { public LowStockForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Low Stock Alerts"; } }
    public partial class UsersForm : KryptonForm { public UsersForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Users Management"; } }
    public partial class RolesForm : KryptonForm { public RolesForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Roles & Permissions"; } }
    public partial class PermissionsForm : KryptonForm { public PermissionsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Permissions Setup"; } }
    public partial class ReportsForm : KryptonForm { public ReportsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Reports (Crystal Reports)"; } }
    public partial class AuditLogsForm : KryptonForm { public AuditLogsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Audit Logs"; } }
    public partial class SettingsForm : KryptonForm { public SettingsForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "System Settings"; } }
    public partial class BackupRestoreForm : KryptonForm { public BackupRestoreForm() { InitializeComponent(); } private void InitializeComponent() { this.Text = "Backup & Restore"; } }
}
