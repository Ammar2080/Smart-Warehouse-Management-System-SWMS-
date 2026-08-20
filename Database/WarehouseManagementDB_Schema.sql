-- =====================================================
-- Smart Warehouse Management System (SWMS) - Database Schema
-- SQL Server Script
-- =====================================================

CREATE DATABASE WarehouseManagementDB;
GO

USE WarehouseManagementDB;
GO

-- 1. Users, Roles, Permissions
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Permissions (
    PermissionId INT IDENTITY(1,1) PRIMARY KEY,
    PermissionName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(200)
);

CREATE TABLE RolePermissions (
    RoleId INT FOREIGN KEY REFERENCES Roles(RoleId) ON DELETE CASCADE,
    PermissionId INT FOREIGN KEY REFERENCES Permissions(PermissionId) ON DELETE CASCADE,
    PRIMARY KEY (RoleId, PermissionId)
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    RoleId INT FOREIGN KEY REFERENCES Roles(RoleId),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 2. Categories & Units
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Units (
    UnitId INT IDENTITY(1,1) PRIMARY KEY,
    UnitName NVARCHAR(50) NOT NULL UNIQUE,
    Abbreviation NVARCHAR(20) NOT NULL
);

-- 3. Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductCode NVARCHAR(50) NOT NULL UNIQUE,
    Barcode NVARCHAR(100) UNIQUE,
    ProductName NVARCHAR(150) NOT NULL,
    Description NVARCHAR(500),
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
    UnitId INT FOREIGN KEY REFERENCES Units(UnitId),
    PurchasePrice DECIMAL(18,2) NOT NULL CHECK (PurchasePrice >= 0),
    SellingPrice DECIMAL(18,2) NOT NULL CHECK (SellingPrice >= 0),
    MinimumStock DECIMAL(18,2) DEFAULT 0,
    MaximumStock DECIMAL(18,2) DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- 4. Warehouses & Stock
CREATE TABLE Warehouses (
    WarehouseId INT IDENTITY(1,1) PRIMARY KEY,
    WarehouseCode NVARCHAR(50) NOT NULL UNIQUE,
    WarehouseName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200),
    ManagerName NVARCHAR(100),
    Phone NVARCHAR(50),
    Description NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE WarehouseStock (
    WarehouseStockId INT IDENTITY(1,1) PRIMARY KEY,
    WarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (Quantity >= 0),
    LastUpdated DATETIME DEFAULT GETDATE(),
    CONSTRAINT UQ_Warehouse_Product UNIQUE (WarehouseId, ProductId)
);

-- 5. Suppliers & Customers
CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierCode NVARCHAR(50) NOT NULL UNIQUE,
    SupplierName NVARCHAR(100) NOT NULL,
    CompanyName NVARCHAR(100),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerCode NVARCHAR(50) NOT NULL UNIQUE,
    CustomerName NVARCHAR(100) NOT NULL,
    CompanyName NVARCHAR(100),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 6. Stock In (Purchases / Receipts)
CREATE TABLE StockIn (
    StockInId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
    SupplierId INT FOREIGN KEY REFERENCES Suppliers(SupplierId),
    WarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    TotalAmount DECIMAL(18,2) NOT NULL,
    Notes NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE StockInDetails (
    DetailId INT IDENTITY(1,1) PRIMARY KEY,
    StockInId INT FOREIGN KEY REFERENCES StockIn(StockInId) ON DELETE CASCADE,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity DECIMAL(18,2) NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    TotalPrice DECIMAL(18,2) NOT NULL
);

-- 7. Stock Out (Sales / Dispatches)
CREATE TABLE StockOut (
    StockOutId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    WarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    TotalAmount DECIMAL(18,2) NOT NULL,
    Notes NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE StockOutDetails (
    DetailId INT IDENTITY(1,1) PRIMARY KEY,
    StockOutId INT FOREIGN KEY REFERENCES StockOut(StockOutId) ON DELETE CASCADE,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity DECIMAL(18,2) NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    TotalPrice DECIMAL(18,2) NOT NULL
);

-- 8. Stock Transfers
CREATE TABLE StockTransfers (
    TransferId INT IDENTITY(1,1) PRIMARY KEY,
    TransferCode NVARCHAR(50) NOT NULL UNIQUE,
    SourceWarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    DestinationWarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    TransferDate DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(500)
);

CREATE TABLE StockTransferDetails (
    DetailId INT IDENTITY(1,1) PRIMARY KEY,
    TransferId INT FOREIGN KEY REFERENCES StockTransfers(TransferId) ON DELETE CASCADE,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity DECIMAL(18,2) NOT NULL CHECK (Quantity > 0)
);

-- 9. Stock Adjustments
CREATE TABLE StockAdjustments (
    AdjustmentId INT IDENTITY(1,1) PRIMARY KEY,
    AdjustmentCode NVARCHAR(50) NOT NULL UNIQUE,
    WarehouseId INT FOREIGN KEY REFERENCES Warehouses(WarehouseId),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    Reason NVARCHAR(255) NOT NULL,
    AdjustmentDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE StockAdjustmentDetails (
    DetailId INT IDENTITY(1,1) PRIMARY KEY,
    AdjustmentId INT FOREIGN KEY REFERENCES StockAdjustments(AdjustmentId) ON DELETE CASCADE,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    OldQuantity DECIMAL(18,2) NOT NULL,
    NewQuantity DECIMAL(18,2) NOT NULL,
    Difference DECIMAL(18,2) NOT NULL
);

-- 10. Audit Logs
CREATE TABLE AuditLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    Action NVARCHAR(100) NOT NULL,
    TableName NVARCHAR(50),
    RecordId INT,
    Details NVARCHAR(MAX),
    IpAddress NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- =====================================================
-- Seed Data for Initial Testing (SQL Server 2022 Compatible)
-- =====================================================

INSERT INTO Roles (RoleName, Description) VALUES 
(N'مدير النظام', N'صلاحيات كاملة على كافة أقسام النظام'),
(N'أمين مستودع', N'إدارة حركة المخزون والإدخال والصرف');
GO

INSERT INTO Users (Username, PasswordHash, FullName, Email, RoleId, IsActive) VALUES 
('admin', '123456', N'مدير النظام العام', 'admin@swms.local', 1, 1),
('storekeeper', '123456', N'أحمد أمين المخزن', 'store@swms.local', 2, 1);
GO

INSERT INTO Categories (CategoryName, Description) VALUES 
(N'إلكترونيات', N'أجهزة ومعدات إلكترونية'),
(N'أدوات مكتبية', N'مستلزمات ومطبوعات مكاتب');
GO

INSERT INTO Units (UnitName, Abbreviation) VALUES 
(N'قطعة', N'Pcs'),
(N'صندوق', N'Box');
GO

INSERT INTO Warehouses (WarehouseCode, WarehouseName, Location, ManagerName, Phone) VALUES 
('WH-01', N'المستودع الرئيسي - الرياض', N'المنطقة الصناعية الأولى', N'محمد خالد', '0501234567'),
('WH-02', N'مستودع الفرع - جدة', N'حي الروابي', N'سعيد أحمد', '0559876543');
GO
