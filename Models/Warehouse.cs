using System;

namespace WarehouseManagement.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
