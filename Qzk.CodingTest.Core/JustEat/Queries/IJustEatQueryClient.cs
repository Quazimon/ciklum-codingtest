using System.Threading.Tasks;
using Qzk.CodingTest.Entities.JustEat;

namespace Qzk.CodingTest.Core.JustEat.Queries
{
    /// <summary>
    /// Used to connect and get information from Just Eat Api.
    /// </summary>
    public interface IJustEatQueryClient
    {
        /// <summary>
        /// Retrieves restaurants information from Just Eat Api based on search criteria.
        /// </summary>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The response from Just Eat Api converted to model.</returns>
        Task<GetRestaurantsResponse> GetRestaurants(string criteria);
    }
}