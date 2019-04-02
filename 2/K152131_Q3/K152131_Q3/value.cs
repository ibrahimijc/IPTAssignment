using Newtonsoft.Json;

namespace K152131_Q3
{
    public class value
    {
        [JsonProperty("bpm")]
        public int bpm { get; set; }

        [JsonProperty("confidence")]
        public int confidence { get; set; }
    }
}
