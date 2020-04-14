﻿using System;
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
                        
            if (Restaurant == null)
                RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = HtmlHelper.GetEnumSelectList<CusineType>();

            if (!ModelState.IsValid)            
                return Page();
            
            RestaurantData.Update(Restaurant);
            return RedirectToPage("./List");
        }

        #endregion
    }
}
