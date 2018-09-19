using System.Collections.Generic;

namespace Qzk.CodingTest.Entities.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> Cuisines { get; set; }
    }
}
