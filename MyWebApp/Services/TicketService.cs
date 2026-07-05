using MyWebApp.Models;
using MyWebApp.SupabaseClient;
using Newtonsoft.Json;
using Supabase.Gotrue;

namespace MyWebApp.Services
{
    public static class TicketService
    {
        // Helper para inyectar la sesión en el cliente sin repetir código
        private static async Task InyectarSesion(Supabase.Client client, string sessionJson)
        {
            if (!string.IsNullOrEmpty(sessionJson))
            {
                var session = JsonConvert.DeserializeObject<Session>(sessionJson);
                if (session?.AccessToken != null && session?.RefreshToken != null)
                {
                    // La forma correcta en C# de restaurar la sesión y sus headers
                    await client.Auth.SetSession(session.AccessToken, session.RefreshToken);
                }
            }
        }

        public static async Task<List<Ticket>> getAll(string sessionJson)
        {
            Supabase.Client client = SupabClient.getSupabaseClient();
            await client.InitializeAsync();

            await InyectarSesion(client, sessionJson);

            var result = await client.From<Ticket>().Get();
            return result.Models ?? new List<Ticket>();
        }

        public static async Task<Ticket?> getTicketById(long id, string sessionJson)
        {
            Supabase.Client client = SupabClient.getSupabaseClient();
            await client.InitializeAsync();

            await InyectarSesion(client, sessionJson);

            var result = await client.From<Ticket>().Where(x => x.Id == id).Get();
            var comments = await client.From<Comment>().Where(x => x.TicketId == id).Get();

            if (result.Model != null)
            {
                result.Model.Comments = comments.Models ?? new List<Comment>();
            }

            return result.Model;
        }

        public static async Task postComment(Comment comment, string sessionJson)
        {
            Supabase.Client client = SupabClient.getSupabaseClient();
            await client.InitializeAsync();

            await InyectarSesion(client, sessionJson);

            await client.From<Comment>().Insert(comment);
        }

        public static async Task deleteComment(int commentId, string sessionJson)
        {
            Supabase.Client client = SupabClient.getSupabaseClient();
            await client.InitializeAsync();

            await InyectarSesion(client, sessionJson);

            await client.From<Comment>().Where(x => x.Id == commentId).Delete();
        }
    }
}