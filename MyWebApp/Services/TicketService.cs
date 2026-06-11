using MyWebApp.Models;
using MyWebApp.SupabaseClient;
using Supabase;

namespace MyWebApp.Services
{
    public static class TicketService
    {
        public static async Task<List<Ticket>> getAll()
        {
            Client client = SupabClient.getSupabaseClient();

            await client.InitializeAsync();

            var result = await client.From<Ticket>().Get();
            return result.Models;
        }
    }
}
