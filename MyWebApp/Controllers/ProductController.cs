using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class ProductController : Controller
    {       
        public IActionResult Index()
        {
            List<Product> list = ProductService.getAll();

            return View(list);
        }
    }
}
