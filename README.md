# Smart Warehouse Management System (SWMS)

 نظام احترافي لإدارة المستودعات والمخزون، تم تطويره باستخدام **C# Windows Forms**, **.NET Framework**, و **SQL Server** مع الالتزام التام بالمعمارية متعددة الطبقات (Multi-Tier Architecture) ونمط الاتصال المباشر (**ADO.NET Connected Mode**).

---

## 🏗️ المعمارية الهندسية للمشروع (Architecture)

يتم تنظيم الحل (Solution) ضمن مشاريع منفصلة ومترابطة بدقة لضمان قابلية التوسع والصيانة:

```text
WarehouseManagement
│
├── Presentation (واجهات المستخدم باستخدام Krypton Toolkit)
├── BusinessLogic (منطق الأعمال وقواعد التحقق والتحقق من المخزون)
├── DataAccess (طبقة الوصول للبيانات باستخدام ADO.NET Connected Mode)
├── Models (كائنات البيانات والهياكل والـ Collections)
└── Reports (التقارير باستخدام SAP Crystal Reports)
```

### اتجاه تدفق البيانات:
```text
Presentation (Forms) ──> BusinessLogic (Services) ──> DataAccess (DAL) ──> SQL Server
```

---

## 🛠️ التقنيات المستخدمة (Tech Stack)
- **Programming Language**: C# (.NET Framework / .NET Core WinForms)
- **UI Framework**: Krypton Toolkit (تصميم حديث وعصري)
- **Database**: Microsoft SQL Server
- **Data Access Layer**: ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`, `SqlParameter`)
- **Reporting**: SAP Crystal Reports
- **Collections**: `List<T>` للتمرير الآمن والمنظم للبيانات بين الطبقات.

---

## 🗄️ قاعدة البيانات (Database Schema)
تم إرفاق سكีبت قاعدة البيانات المتكامل في مجلد `/Database/WarehouseManagementDB_Schema.sql` والذي يتضمن الجداول التالية مع القيود والعلاقات:
1. `Users`, `Roles`, `Permissions`, `RolePermissions`
2. `Categories`, `Units`, `Products`
3. `Warehouses`, `WarehouseStock` (مع قيد `UNIQUE(WarehouseId, ProductId)`)
4. `Suppliers`, `Customers`
5. `StockIn`, `StockInDetails` (سندات الإدخال والشراء)
6. `StockOut`, `StockOutDetails` (سندات الصرف والبيع)
7. `StockTransfers`, `StockTransferDetails` (تحويلات المخزون بين المستودعات)
8. `StockAdjustments`, `StockAdjustmentDetails` (تسويات المخزون والجرد)
9. `AuditLogs` (سجل العمليات والتدقيق)

---

## 🚀 تعليمات التشغيل والجلب (Getting Started & Clone)

لجلب المشروع وتشغيله على جهازك المحلي عبر Git:

```bash
git clone https://github.com/Ammar2080/Smart-Warehouse-Management-System-SWMS-.git
cd Smart-Warehouse-Management-System-SWMS-
```

1. افتح ملف `WarehouseManagementDB_Schema.sql` في SQL Server Management Studio (SSMS) ونفذه لإنشاء قاعدة البيانات وجداولها.
2. افتح ملف الـ Solution `WarehouseManagement.sln` باستخدام **Visual Studio**.
3. قم بتحديث `App.config` في طبقة العرض (`Presentation`) برابط الاتصال الخاص بقاعدة بياناتك (`Server=YOUR_SERVER;Database=WarehouseManagementDB;Trusted_Connection=True;`).
4. اضغط `F5` لبناء وتشغيل النظام.

---

## 📋 النماذج والواجهات المجهزة (Forms)
- **Authentication & Dashboard**: `LoginForm`, `MainForm`, `DashboardForm`
- **Product Management**: `ProductsForm`, `ProductDetailsForm`, `CategoriesForm`, `UnitsForm`
- **Partners & Warehouses**: `SuppliersForm`, `CustomersForm`, `WarehousesForm`
- **Inventory Operations**: `StockInForm`, `StockOutForm`, `StockTransferForm`, `StockAdjustmentForm`, `InventoryForm`, `LowStockForm`
- **System & Security**: `UsersForm`, `RolesForm`, `PermissionsForm`, `ReportsForm`, `AuditLogsForm`, `SettingsForm`, `BackupRestoreForm`
