using System.Collections.Generic;
using OdeToFood.Core;

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

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }
    }
}
