using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages
{
    public class DetailsModel : PageModel
    {
        #region Properties

        public Restaurant Restaurant { get; set; }

        private IRestaurantData restaurantData { get; set; }

        #endregion

        #region Constructor

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        #endregion


        #region Methods       
        public void OnGet(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            Restaurant = restaurantData.FindRestaurant(id);
        }
        #endregion
    }
}
