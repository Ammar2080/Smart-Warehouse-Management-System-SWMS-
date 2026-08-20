using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class StockOut
    {
        public int StockOutId { get; set; }
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<StockOutDetail> Details { get; set; } = new List<StockOutDetail>();
    }

    public class StockOutDetail
    {
        public int DetailId { get; set; }
        public int StockOutId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class StockTransfer
    {
        public int TransferId { get; set; }
        public string TransferCode { get; set; }
        public int SourceWarehouseId { get; set; }
        public string SourceWarehouseName { get; set; }
        public int DestinationWarehouseId { get; set; }
        public string DestinationWarehouseName { get; set; }
        public int UserId { get; set; }
        public DateTime TransferDate { get; set; }
        public string Notes { get; set; }
    }

    public class StockAdjustment
    {
        public int AdjustmentId { get; set; }
        public string AdjustmentCode { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime AdjustmentDate { get; set; }
    }

    public class AuditLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }
        public string Details { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
