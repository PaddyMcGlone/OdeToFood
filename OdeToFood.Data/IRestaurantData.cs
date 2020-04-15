using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {        
        IEnumerable<Restaurant> FindRestaurants(string name = null);

        Restaurant FindRestaurant(int id);

        Restaurant Update(Restaurant UpdatedRestaurant);

        Restaurant Add(Restaurant NewRestaurant);

        Restaurant DeleteRestaurant(int id);

        int Commit();
    }
}
