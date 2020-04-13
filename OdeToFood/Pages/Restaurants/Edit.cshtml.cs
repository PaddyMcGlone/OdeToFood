using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        #region Properties

        public Restaurant restaurant { get; set; }
        public IRestaurantData RestaurantData { get; }

        #endregion

        #region Constructor

        public EditModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        #endregion

        #region Methods

        public IActionResult OnGet(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            restaurant = RestaurantData.FindRestaurant(id);

            if (restaurant == null)
                RedirectToPage("./NotFound");

            return Page();
        }

        #endregion
    }
}
