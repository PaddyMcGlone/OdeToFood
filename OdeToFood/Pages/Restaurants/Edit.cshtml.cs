using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        #region Properties

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public string CancelDestination { get; set; }

        private IRestaurantData RestaurantData { get; }

        private IHtmlHelper HtmlHelper { get; }
         
        #endregion

        #region Constructor

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;
            HtmlHelper = htmlHelper;
        }

        #endregion

        #region Methods

        public IActionResult OnGet(int? id)
        {
                        
            Cuisines = HtmlHelper.GetEnumSelectList<CusineType>();

            Restaurant = id.HasValue ? RestaurantData.FindRestaurant(id.Value)
                : new Restaurant();

            CancelDestination = id.HasValue ? "./Details" : "./List";
                        
            if (Restaurant == null)
                RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {            
            if (!ModelState.IsValid)
            {
                Cuisines = HtmlHelper.GetEnumSelectList<CusineType>();
                return Page();
            }

            Restaurant = Restaurant.Id > 0 ?
                RestaurantData.Update(Restaurant):
                RestaurantData.Add(Restaurant);

            _ = RestaurantData.Commit();

            TempData["Message"] = "Restaurant saved.";
            return RedirectToPage("./Details", new { Restaurant.Id });
        }

        #endregion
    }
}
