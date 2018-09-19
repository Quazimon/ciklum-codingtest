using System.Collections.Generic;

namespace Qzk.CodingTest.Entities.JustEat
{
    public class GetRestaurantsResponse
    {
        public List<Restaurant> Restaurants { get; set; }
        public string ShortResultText { get; set; }
        public string Area { get; set; }
        public List<object> Errors { get; set; }
        public bool HasErrors { get; set; }
        public MetaData MetaData { get; set; }
    }
}
