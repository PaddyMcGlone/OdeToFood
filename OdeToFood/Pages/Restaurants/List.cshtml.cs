using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {                 
        #region Properties
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        private IRestaurantData RestaurantData { get; }
        #endregion

        #region Constructor
        public ListModel(IRestaurantData restaurantData)
        {            
            RestaurantData = restaurantData;
        }
        #endregion

        #region Action methods
        public void OnGet()
        {
            Restaurants = RestaurantData.FindRestaurants(SearchTerm);
        }
        #endregion
    }
}
