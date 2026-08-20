using System;
using System.Collections.Generic;
using WarehouseManagement.DataAccess;
using WarehouseManagement.Models;

namespace WarehouseManagement.BusinessLogic
{
    public class ProductService
    {
        private readonly ProductDAL _productDAL;

        public ProductService()
        {
            _productDAL = new ProductDAL();
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return _productDAL.GetAllProducts();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products in Business Logic: " + ex.Message);
            }
        }

        public bool AddProduct(Product product)
        {
            // Business validations & rules
            if (string.IsNullOrWhiteSpace(product.ProductCode))
                throw new ArgumentException("Product code cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name cannot be empty.");

            if (product.PurchasePrice < 0 || product.SellingPrice < 0)
                throw new ArgumentException("Prices cannot be negative.");

            if (product.MinimumStock < 0 || product.MaximumStock < 0)
                throw new ArgumentException("Stock limits cannot be negative.");

            if (product.MaximumStock > 0 && product.MinimumStock > product.MaximumStock)
                throw new ArgumentException("Minimum stock cannot exceed maximum stock.");

            return _productDAL.InsertProduct(product);
        }
    }
}
