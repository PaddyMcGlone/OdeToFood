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

        public Restaurant Restaurant { get; set; }        
        public IEnumerable<SelectListItem> Cuisines { get; set; }
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

        public IActionResult OnGet(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            // Build the cuisine select list.
            Cuisines = HtmlHelper.GetEnumSelectList<CusineType>();
            Restaurant = RestaurantData.FindRestaurant(id);

            if (Restaurant == null)
                RedirectToPage("./NotFound");

            return Page();
        }

        #endregion
    }
}
