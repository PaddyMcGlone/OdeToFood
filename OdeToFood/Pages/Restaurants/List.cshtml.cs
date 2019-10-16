using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {         
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private IRestaurantData RestaurantData { get; }

        public ListModel(IRestaurantData restaurantData)
        {            
            RestaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = RestaurantData.GetAll();
        }
    }
}
