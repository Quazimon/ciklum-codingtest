using System.Collections.Generic;
using System.Threading.Tasks;
using Qzk.CodingTest.Entities.Models;

namespace Qzk.CodingTest.Core.Services
{
    /// <summary>
    /// Used to retrieve restaurants information.
    /// </summary>
    public interface IRestaurantsQueryService
    {
        /// <summary>
        /// Retrieves open restaurants information based on search criteria.
        /// </summary>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The collection of restaurants.</returns>
        Task<IEnumerable<Restaurant>> GetOpenRestaurants(string criteria);
    }
}