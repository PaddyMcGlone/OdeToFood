using System;
using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public OdeToFoodDbContext Context { get; }

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public Restaurant Add(Restaurant NewRestaurant)
        {
            Context.Restaurants.Add(NewRestaurant);

            return NewRestaurant;
        }        

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = FindRestaurant(id);

            if (restaurant != null)            
                Context.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public Restaurant FindRestaurant(int id)
        {
            return Context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> FindRestaurants(string name = null)
        {
            var query = from r in Context.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var entity = Context.Restaurants.Attach(UpdatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return UpdatedRestaurant;
        }


    }
}
