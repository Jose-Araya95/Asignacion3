using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;
using Newtonsoft.Json;
using Supabase.Gotrue;

namespace MyWebApp.Controllers
{
    public class TicketController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string? sessionJson = HttpContext.Session.GetString("session");

            if (string.IsNullOrEmpty(sessionJson))
                return RedirectToAction("Index", "Login");

            List<Ticket> ticketList = await TicketService.getAll(sessionJson);

            return View(ticketList);
        }

        // Cambiado de int a long
        public async Task<IActionResult> Detail(long id)
        {
            string? sessionJson = HttpContext.Session.GetString("session");

            if (string.IsNullOrEmpty(sessionJson))
                return RedirectToAction("Index", "Login");

            Session? session = JsonConvert.DeserializeObject<Session>(sessionJson);

            Ticket? detail = await TicketService.getTicketById(id, sessionJson);

            if (detail != null && session?.User != null)
            {
                detail.ActiveSessionUserId = session.User.Id;
            }

            return View(detail);
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(string ticketId, string commentText)
        {
            string? sessionJson = HttpContext.Session.GetString("session");

            if (string.IsNullOrEmpty(sessionJson))
                return RedirectToAction("Index", "Login");

            Session? session = JsonConvert.DeserializeObject<Session>(sessionJson);

            // Convertimos de antemano el id a entero para que coincida con el método Detail(int id)
            int idAsInt = Convert.ToInt32(ticketId);

            Comment comment = new Comment
            {
                CommentText = commentText,
                TicketId = idAsInt,
                CreatedBy = session?.User?.Id,
                CreatedAt = DateTime.Now,
            };

            await TicketService.postComment(comment, sessionJson);

            // Redirección explícita pasando el parámetro exacto 'id' como entero
            return RedirectToAction("Detail", "Ticket", new { id = idAsInt });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(string ticketId, int commentId)
        {
            string? sessionJson = HttpContext.Session.GetString("session");

            if (string.IsNullOrEmpty(sessionJson))
                return RedirectToAction("Index", "Login");

            int idAsInt = Convert.ToInt32(ticketId);

            await TicketService.deleteComment(commentId, sessionJson);

            // Redirección explícita pasando el parámetro exacto 'id' como entero
            return RedirectToAction("Detail", "Ticket", new { id = idAsInt });
        }
    }
}