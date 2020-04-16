using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public SqlRestaurantData()
        {
        }

        public Restaurant Add(Restaurant NewRestaurant)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Restaurant DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant FindRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> FindRestaurants(string name = null)
        {
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            throw new NotImplementedException();
        }
    }
}
