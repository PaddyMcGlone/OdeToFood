using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
        public ILogger<ListModel> Logger { get; }
        #endregion

        #region Constructor
        public ListModel(IRestaurantData restaurantData,
                         ILogger<ListModel> logger)
        {
            RestaurantData = restaurantData;
            Logger = logger;
        }
        #endregion

        #region Action methods
        public void OnGet()
        {
            Logger.LogWarning("You have accessed this List model page");
            Logger.LogError("An error has occurred.");
            Restaurants = RestaurantData.FindRestaurants(SearchTerm);
        }
        #endregion
    }
}
