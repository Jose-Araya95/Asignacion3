using Supabase;

namespace MyWebApp.SupabaseClient
{
    public static class SupabClient
    {
        private static string url = "https://supabase.co/";
        private static string key = "";

        public static Client getSupabaseClient()
        {
            return new Client(url, key);
        }
    }
}
