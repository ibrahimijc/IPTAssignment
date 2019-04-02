using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace K152131_Q3
{
    public class userDetail
    {
        [JsonProperty("dateTime")]
        public string dateTime { get; set; }

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
