using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;

namespace MyWebApp.Controllers
{
    public class ProductController : Controller
    {       
        public IActionResult Index()
        {
            List<Product> list = ProductService.getAll();

            return View(list);
        }

        public IActionResult Detail(int id)
        {
            ProductDetail detail = ProductService.getProductDetail(id);

            return View(detail);
        }

        public IActionResult Edit(ProductDetail detail)
        {
            ProductService.saveProductDetail(detail);

            return RedirectToAction("Detail", new { Id = detail.ProductId });
        }
    }
}
