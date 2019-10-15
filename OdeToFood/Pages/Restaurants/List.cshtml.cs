using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;

        public string Message { get; set; }

        public ListModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            Message = $"Hello, world! from {_config["MyName"]}";
        }
    }
}
