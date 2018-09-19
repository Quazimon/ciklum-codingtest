using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Qzk.CodingTest.Core.JustEat.Queries;
using Qzk.CodingTest.Core.JustEat.Queries.Impl;
using Qzk.CodingTest.Entities.Models;

namespace Qzk.CodingTest.Core.Services.Impl
{
    public class RestaurantsQueryService : IRestaurantsQueryService
    {
        private readonly IJustEatQueryClient _justEatQueryClient;

        public RestaurantsQueryService(IJustEatQueryClient justEatQueryClient)
        {
            _justEatQueryClient = justEatQueryClient;
        }

        public async Task<IEnumerable<Restaurant>> GetOpenRestaurants(string criteria)
        {
            var getRestaurantsResponse = await _justEatQueryClient.GetRestaurants(criteria);

            if (getRestaurantsResponse == null)
            {
                // TODO Log errors.
                return new List<Restaurant>();
            }

            if (getRestaurantsResponse.HasErrors)
            {
                // TODO Log errors.
                return new List<Restaurant>();
            }

            if (!getRestaurantsResponse.Restaurants.Any())
            {
                return new List<Restaurant>();
            }

            var openRestaurants = getRestaurantsResponse.Restaurants
                .Where(r => r.IsOpenNow)
                .OrderByDescending(r => r.Score)
                .Select(r => new Restaurant
                {
                    Name = r.Name,
                    Rating = r.Score,
                    Cuisines = r.CuisineTypes.Select(ct => ct.Name)
                });

            return openRestaurants;
        }
    }
}
