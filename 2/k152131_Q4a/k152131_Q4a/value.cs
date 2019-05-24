using Newtonsoft.Json;

namespace k152131_Q4a
{
    public class value
    {
        [JsonProperty("bpm")]
        public int bpm { get; set; }

        [JsonProperty("confidence")]
        public int confidence { get; set; }
    }
}
