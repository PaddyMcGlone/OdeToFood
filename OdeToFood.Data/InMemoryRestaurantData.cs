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

        public Restaurant Add(Restaurant NewRestaurant)
        {
            restaurants.Add(NewRestaurant);
            NewRestaurant.Id = restaurants.Max(r => r.Id) + 1; 
            return NewRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == id);

            if (restaurant != null)
                restaurants.Remove(restaurant);

            return restaurant;
        }

        public Restaurant FindRestaurant(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> FindRestaurants(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == UpdatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Id       = UpdatedRestaurant.Id;
                restaurant.Name     = UpdatedRestaurant.Name;
                restaurant.Location = UpdatedRestaurant.Location;
                restaurant.Cusine   = UpdatedRestaurant.Cusine;
            }

            Commit();

            return restaurant;
        }
    }
}
