using Microsoft.Data.SqlClient;
using MyWebApp.DatabaseHelper;
using MyWebApp.Models;
using System.Data;
using System.Drawing;

namespace MyWebApp.Services
{
    public static class ProductService
    {
        public static List<Product> getAll()
        {
            List<Product> list = new List<Product>();

            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspGetProducts]", null);

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

        public static ProductDetail getProductDetail(int id)
        {
            List<Product> list = new List<Product>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspGetProductDetail]", parameters);

            if (ds != null)
            {
                foreach (DataRow dr in ds.Rows)
                {
                    ProductDetail detail = new ProductDetail();

                    detail.ProductId = Convert.ToInt32(dr["ProductID"]);
                    detail.ProductName = dr["ProductName"].ToString() ?? string.Empty;
                    detail.ProductNumber = dr["ProductNumber"].ToString() ?? string.Empty;
                    detail.MakeFlag = Convert.ToBoolean(dr["MakeFlag"]);
                    detail.FinishedGoodsFlag = Convert.ToBoolean(dr["FinishedGoodsFlag"]);
                    detail.Color = dr["Color"] == DBNull.Value ? null : dr["Color"].ToString();
                    detail.SafetyStockLevel = Convert.ToInt16(dr["SafetyStockLevel"]);
                    detail.ReorderPoint = Convert.ToInt16(dr["ReorderPoint"]);
                    detail.CurrentStandardCost = Convert.ToDecimal(dr["CurrentStandardCost"]);
                    detail.CurrentListPrice = Convert.ToDecimal(dr["CurrentListPrice"]);
                    detail.Size = dr["Size"] == DBNull.Value ? null : dr["Size"].ToString();
                    detail.SizeUnitMeasureCode = dr["SizeUnitMeasureCode"] == DBNull.Value ? null : dr["SizeUnitMeasureCode"].ToString();
                    detail.WeightUnitMeasureCode = dr["WeightUnitMeasureCode"] == DBNull.Value ? null : dr["WeightUnitMeasureCode"].ToString();
                    detail.Weight = dr["Weight"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(dr["Weight"]);
                    detail.DaysToManufacture = Convert.ToInt32(dr["DaysToManufacture"]);
                    detail.ProductLine = dr["ProductLine"] == DBNull.Value ? null : dr["ProductLine"].ToString();
                    detail.Class = dr["Class"] == DBNull.Value ? null : dr["Class"].ToString();
                    detail.Style = dr["Style"] == DBNull.Value ? null : dr["Style"].ToString();
                    detail.SellStartDate = Convert.ToDateTime(dr["SellStartDate"]);
                    detail.SellEndDate = dr["SellEndDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dr["SellEndDate"]);
                    detail.DiscontinuedDate = dr["DiscontinuedDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dr["DiscontinuedDate"]);
                    detail.TotalQuantityInStock = Convert.ToInt32(dr["TotalQuantityInStock"]);

                    return detail;
                }
            }

            return null;
        }

        public static void saveProductDetail(ProductDetail detail)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = "@ProductId", Value = (object)detail.ProductId ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@ProductName", Value = (object)detail.ProductName ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@ProductNumber", Value = (object)detail.ProductNumber ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@MakeFlag", Value = (object)detail.MakeFlag ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@FinishedGoodsFlag", Value = (object)detail.FinishedGoodsFlag ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@Color", Value = (object)detail.Color ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@SafetyStockLevel", Value = (object)detail.SafetyStockLevel ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@ReorderPoint", Value = (object)detail.ReorderPoint ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@CurrentStandardCost", Value = (object)detail.CurrentStandardCost ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@CurrentListPrice", Value = (object)detail.CurrentListPrice ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@Size", Value = (object)detail.Size ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@SizeUnitMeasureCode", Value = (object)detail.SizeUnitMeasureCode ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@WeightUnitMeasureCode", Value = (object)detail.WeightUnitMeasureCode ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@Weight", Value = (object)detail.Weight ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@DaysToManufacture", Value = (object)detail.DaysToManufacture ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@ProductLine", Value = (object)detail.ProductLine ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@Class", Value = (object)detail.Class ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@Style", Value = (object)detail.Style ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@SellStartDate", Value = (object)detail.SellStartDate ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@SellEndDate", Value = (object)detail.SellEndDate ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@DiscontinuedDate", Value = (object)detail.DiscontinuedDate ?? DBNull.Value });
            parameters.Add(new SqlParameter { ParameterName = "@TotalQuantityInStock", Value = (object)detail.TotalQuantityInStock ?? DBNull.Value });


            DataTable ds = DatabaseSql.executeStoredProcedure("[dbo].[uspUpdateProduct]", parameters);
        }
    }
}
