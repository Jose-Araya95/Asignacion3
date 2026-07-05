using Microsoft.AspNetCore.Mvc;
using MyWebApp.Auth;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ValidateLogin(UserModel user)
        {
            // Validar que los campos no vengan nulos
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Pwd))
            {
                ViewBag.ErrorMessage = "Debe ingresar correo y contraseña.";
                return View("Index");
            }

            var (session, errorMessage) = await SupabaseAuthentication.SignIn(user.Email, user.Pwd);

            if (session != null)
            {
                HttpContext.Session.SetString("session", JsonConvert.SerializeObject(session));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Pasamos el error al ViewBag para que la Partial View lo muestre
                ViewBag.ErrorMessage = errorMessage;
                return View("Index");
            }
        }
    }
}