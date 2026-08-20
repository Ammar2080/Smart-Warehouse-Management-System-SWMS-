using System;
using System.Collections.Generic;
using WarehouseManagement.DataAccess;
using WarehouseManagement.Models;

namespace WarehouseManagement.BusinessLogic
{
    public class SupplierService
    {
        private readonly SupplierDAL _dal = new SupplierDAL();
        public List<Supplier> GetAllSuppliers() => _dal.GetAllSuppliers();
    }

    public class CustomerService
    {
        private readonly CustomerDAL _dal = new CustomerDAL();
        public List<Customer> GetAllCustomers() => _dal.GetAllCustomers();
    }

    public class WarehouseService
    {
        private readonly WarehouseDAL _dal = new WarehouseDAL();
        public List<Warehouse> GetAllWarehouses() => _dal.GetAllWarehouses();
    }

    public class InventoryService
    {
        private readonly InventoryDAL _dal = new InventoryDAL();
        public List<InventoryItem> GetStockByWarehouse(int warehouseId) => _dal.GetWarehouseStock(warehouseId);
    }
}
