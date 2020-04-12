using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;        

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 1, Name = "Pizza the action", Cusine = CusineType.Italian, Location = "Belfast"},
                new Restaurant{ Id = 2, Name = "Dawali", Cusine = CusineType.Indian, Location = "Belfast"},
                new Restaurant{ Id = 3, Name = "New Mexico", Cusine = CusineType.Mexican, Location = "Belfast"}
            };
        }        

        public IEnumerable<Restaurant> FindRestaurants(string name = null)
        {
            /*return from r in restaurants
            where string.IsNullOrWhiteSpace(name) || r.Name.ToLower().StartsWith(name.ToLower())
            orderby r.Name
            select r;*/

            /* if (string.IsNullOrEmpty(name))
                return restaurants.OrderBy(r => r.Name);

            return restaurants
                .Where(r => r.Name.ToLower().StartsWith(name.ToLower()))
                .OrderBy(r => r.Name); */

            return from r in restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }
    }
}
