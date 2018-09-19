using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qzk.CodingTest.Core.JustEat.Queries;
using Qzk.CodingTest.Core.JustEat.Queries.Impl;
using Qzk.CodingTest.Core.Services;
using Qzk.CodingTest.Core.Services.Impl;
using Qzk.CodingTest.Entities.Settings;

namespace Qzk.CodingTest.Core.Tests
{
    [TestClass]
    public class RestaurantsQueryServiceTests
    {
        private readonly IRestaurantsQueryService _restaurantsQueryService;

        public RestaurantsQueryServiceTests()
        {
            var justEatApiSettings = Options.Create(new JustEatApiSettings
            {
                Url = "https://public.je-apis.com/",
                AuthSchema = "Basic",
                AuthToken = "VGVjaFRlc3Q6bkQ2NGxXVnZreDVw"
            });

            IJustEatQueryClient justEatQueryClient = new JustEatQueryClient(justEatApiSettings);

            _restaurantsQueryService = new RestaurantsQueryService(justEatQueryClient);
        }

        [TestMethod]
        public void GetOpenRestaurants_ValidParameterPassed()
        {
            const string searchCriteria = "se19";

            var result = _restaurantsQueryService.GetOpenRestaurants(searchCriteria).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetOpenRestaurants_InvalidParameterPassed()
        {
            const string searchCriteria = "hello";

            var result = _restaurantsQueryService.GetOpenRestaurants(searchCriteria).Result;

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }
    }
}
