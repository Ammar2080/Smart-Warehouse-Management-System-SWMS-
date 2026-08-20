namespace WarehouseManagement.Presentation.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelSidebar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelContent;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnProducts;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnInventory;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStockIn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStockOut;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSuppliers;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCustomers;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReports;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSettings;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblHeaderTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSettings = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReports = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCustomers = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSuppliers = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStockOut = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStockIn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnInventory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnProducts = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelHeader = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblHeaderTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panelContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblWelcome = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelSidebar)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnCustomers);
            this.panelSidebar.Controls.Add(this.btnSuppliers);
            this.panelSidebar.Controls.Add(this.btnStockOut);
            this.panelSidebar.Controls.Add(this.btnStockIn);
            this.panelSidebar.Controls.Add(this.btnInventory);
            this.panelSidebar.Controls.Add(this.btnProducts);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(808, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 681);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.Location = new System.Drawing.Point(0, 315);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(220, 45);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Values.Text = "إعدادات النظام";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.Location = new System.Drawing.Point(0, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 45);
            this.btnReports.TabIndex = 6;
            this.btnReports.Values.Text = "التقارير والإحصائيات";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.Location = new System.Drawing.Point(0, 225);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(220, 45);
            this.btnCustomers.TabIndex = 5;
            this.btnCustomers.Values.Text = "إدارة العملاء";
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppliers.Location = new System.Drawing.Point(0, 180);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(220, 45);
            this.btnSuppliers.TabIndex = 4;
            this.btnSuppliers.Values.Text = "إدارة الموردين";
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnStockOut
            // 
            this.btnStockOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockOut.Location = new System.Drawing.Point(0, 135);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(220, 45);
            this.btnStockOut.TabIndex = 3;
            this.btnStockOut.Values.Text = "سندات الصرف (مبيعات)";
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockIn.Location = new System.Drawing.Point(0, 90);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(220, 45);
            this.btnStockIn.TabIndex = 2;
            this.btnStockIn.Values.Text = "سندات الإدخال (مشتريات)";
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Location = new System.Drawing.Point(0, 45);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(220, 45);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Values.Text = "إدارة المخزون والجرد";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.Location = new System.Drawing.Point(0, 0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(220, 45);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Values.Text = "إدارة المنتجات والأصناف";
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(808, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Location = new System.Drawing.Point(300, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(208, 27);
            this.lblHeaderTitle.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Values.Text = "نظام إدارة المستودعات الذكي";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(808, 621);
            this.panelContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Location = new System.Drawing.Point(220, 250);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(368, 33);
            this.lblWelcome.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Values.Text = "مرحباً بك في لوحة تحكم نظام المستودعات";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 681);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الواجهة الرئيسية - نظام المستودعات الذكي";
            ((System.ComponentModel.ISupportInitialize)(this.panelSidebar)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
