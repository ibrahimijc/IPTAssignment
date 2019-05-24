using Newtonsoft.Json;


namespace k152131_Q4a
{
    public class userDetail
    {
        [JsonProperty("dateTime")]
        public string dateTime { get; set; }

        [JsonProperty("age")]
        public int age { get; set; }


        [JsonProperty("email")]
        public string email { get; set; }


        [JsonProperty("value")]
        public value val { get; set; }

        userDetail()
        {
            val = new value();
        }

    }

}
