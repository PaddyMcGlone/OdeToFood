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
    public class DeleteModel : PageModel
    {
        public Restaurant restaurant { get; set; }

        public IRestaurantData RestaurantData { get; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }        

        public IActionResult OnGet(int id)
        {
        }

        public IActionResult OnPost(int id)
        {

        }
    }
}
