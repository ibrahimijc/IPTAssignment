using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k152131_Q2
{
    public class value
    {
        [JsonProperty("bpm")]
        public int bpm { get; set; }

        [JsonProperty("confidence")]
        public int confidence { get; set; }
    }
}
