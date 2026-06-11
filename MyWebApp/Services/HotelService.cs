using MyWebApp.Models;

namespace MyWebApp.Services
{
    public static class HotelService
    {
        public static List<Hotel> getAll()
        {
            List<Hotel> hotels = new List<Hotel>();

            hotels.Add(new Hotel
            {
                Id = 1,
                Name = "Hotel Papagayo",
                Address = "Guanacaste, Costa Rica",
                Description = "",
                Photo = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/12/03/b5/12/occidental-papagayo-adults.jpg?w=900&h=-1&s=1"
            });

            hotels.Add(new Hotel
            {
                Id = 1,
                Name = "Hotel Fiesta Puntarenas",
                Address = "Puntarenas, Costa Rica",
                Description = "",
                Photo = "https://images.trvl-media.com/lodging/18000000/17770000/17763500/17763483/18e5786a.jpg"
            });

            hotels.Add(new Hotel
            {
                Id = 1,
                Name = "Hotel RUI",
                Address = "Guanacaste, Costa Rica",
                Description = "",
                Photo = "https://images.trvl-media.com/lodging/18000000/17770000/17763500/17763483/18e5786a.jpg"
            });

            return hotels;
        }
    }
}
