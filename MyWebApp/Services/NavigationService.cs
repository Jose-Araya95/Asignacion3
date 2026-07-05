using Microsoft.AspNetCore.Identity;
using MyWebApp.Models;

namespace MyWebApp.Services
{
    public static class NavigationService
    {     
        public static List<NavigationPages> GetMenuPages(int userRole)
        {            
            if (userRole == 1) 
            {
                return new List<NavigationPages>
                {
                    new NavigationPages { Title="Home", Controller="Home", Action = "Index"},
                    new NavigationPages { Title="Product", Controller="Product", Action = "Index"},                
                    new NavigationPages { Title="Logout", Controller="Login", Action = "Logout"}
                };
            }
            if (userRole == 2)
            {
                return new List<NavigationPages>
                {
                    new NavigationPages { Title = "Home", Controller = "Home", Action = "Index" },
                    new NavigationPages { Title = "Tickets", Controller = "Ticket", Action = "Index" },
                    new NavigationPages { Title = "Privacy", Controller = "Home", Action = "Privacy" },
                    new NavigationPages { Title = "Settings", Controller = "Home", Action = "Settings" },
                    new NavigationPages { Title="Logout", Controller="Login", Action = "Logout"}
                };
            }

            return new List<NavigationPages>
                {
                    
                };
        }
    }
}
