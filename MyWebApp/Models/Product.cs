using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using MyWebApp.DatabaseHelper;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace MyWebApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNumber { get; set; } = string.Empty;
        public string? Color { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public decimal? Weight { get; set; }
        public string? Model { get; set; }
        public string SubCategory { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNumber { get; set; } = string.Empty;
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal CurrentStandardCost { get; set; }
        public decimal CurrentListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; }
        public string? WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public int TotalQuantityInStock { get; set; }
    }
}
