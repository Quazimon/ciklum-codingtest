using Newtonsoft.Json;

namespace Qzk.CodingTest.Entities.JustEat
{
    public class Logo
    {
        [JsonProperty("StandardResolutionURL")]
        public string StandardResolutionUrl { get; set; }
    }
}
