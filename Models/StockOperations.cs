using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class InventoryItem
    {
        public int WarehouseStockId { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class StockIn
    {
        public int StockInId { get; set; }
        public string InvoiceNumber { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<StockInDetail> Details { get; set; } = new List<StockInDetail>();
    }

    public class StockInDetail
    {
        public int DetailId { get; set; }
        public int StockInId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
