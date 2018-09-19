using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qzk.CodingTest.Core.Services;
using Qzk.CodingTest.Models;

namespace Qzk.CodingTest.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantsQueryService _restaurantsQueryService;

        public RestaurantsController(IRestaurantsQueryService restaurantsQueryService)
        {
            _restaurantsQueryService = restaurantsQueryService;
        }

        public async Task<IActionResult> OpenRestaurants(string criteria)
        {
            var viewModel = new OpenRestaurantsViewModel();

            if (string.IsNullOrEmpty(criteria))
            {
                return View(viewModel);
            }

            var getOpenRestaurantsResult = await _restaurantsQueryService.GetOpenRestaurants(criteria);
            var openRestaurants = getOpenRestaurantsResult.ToList();

            if (openRestaurants.Any())
            {
                viewModel.Restaurants = openRestaurants;
            }


            return View(viewModel);
        }
    }
}