using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qzk.CodingTest.Core.JustEat.Queries;
using Qzk.CodingTest.Core.JustEat.Queries.Impl;
using Qzk.CodingTest.Entities.Settings;

namespace Qzk.CodingTest.Core.Tests
{
    [TestClass]
    public class JustEatQueryClientTests
    {
        private readonly IJustEatQueryClient _justEatQueryClient;

        public JustEatQueryClientTests()
        {
            var justEatApiSettings = Options.Create(new JustEatApiSettings
            {
                Url = "https://public.je-apis.com/",
                AuthSchema = "Basic",
                AuthToken = "VGVjaFRlc3Q6bkQ2NGxXVnZreDVw"
            });

            _justEatQueryClient = new JustEatQueryClient(justEatApiSettings);
        }

        [TestMethod]
        public void GetRestaurants_ValidParameterPassed()
        {
            const string searchCriteria = "se19";

            var result = _justEatQueryClient.GetRestaurants(searchCriteria).Result;

            Assert.IsNotNull(result);
            Assert.IsFalse(result.HasErrors);
            Assert.IsTrue(result.Restaurants.Any());
        }

        [TestMethod]
        public void GetRestaurants_ThrownAnExceptionIfNullPassed()
        {
            const string searchCriteria = null;

            Assert.ThrowsException<AggregateException>(() => _justEatQueryClient.GetRestaurants(searchCriteria).Result);
        }
    }
}
