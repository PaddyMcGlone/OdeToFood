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
        public Restaurant Restaurant { get; set; }

        public IRestaurantData RestaurantData { get; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }        

        public IActionResult OnGet(int id)
        {
            Restaurant = RestaurantData.FindRestaurant(id);

            if (Restaurant == null)            
                RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var restaurant = RestaurantData.DeleteRestaurant(id);
            RestaurantData.Commit();

            if (Restaurant == null)
                RedirectToPage("./NotFound");

            TempData["Message"] = $"{ restaurant.Name} has been deleted.";
            return RedirectToPage("./List");
        }
    }
}
