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

    public static class ProductService
    {
        public static List<Product> getAll()
        {
            List<Product> list = new List<Product>();

            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspGetProducts]");

            if (ds != null)
            {
                foreach (DataRow dr in ds.Rows)
                {
                    Product product = new Product();

                    product.ProductID = (int)dr["ProductID"];
                    product.ProductNumber = dr["ProductNumber"].ToString() ?? string.Empty;
                    product.ProductName = dr["ProductName"].ToString() ?? string.Empty;
                    product.ListPrice = (decimal)dr["ListPrice"];
                    product.Color = dr["Color"].ToString() ?? string.Empty;
                    product.SubCategory = dr["SubCategory"].ToString() ?? string.Empty;
                    product.Category = dr["Category"].ToString() ?? string.Empty;
                    product.Model = dr["Model"].ToString() ?? string.Empty;
                    product.Size = dr["Size"].ToString() ?? string.Empty;
                    product.Weight = dr["Weight"] == DBNull.Value ? null : (decimal)dr["Weight"];
                    list.Add(product);
                }
            }

            return list;
        }
    }
}
