using System.Xml.Serialization;


namespace k152131_Q4a
{
    class userChart
    {
        [XmlAttribute]
        public string Name;

        [XmlAttribute]
        public string Email;

        [XmlAttribute]
        public int HighestHeartRate { get; set; }

        [XmlAttribute]
        public float AvgHeartRate { get; set; }

        [XmlAttribute]
        public int LowestHeartRate { get; set; }

        [XmlAttribute]
        public double Range1 { get; set; }

        [XmlAttribute]
        public double Range2 { get; set; }


        public userChart(string name, int high, int low, float avg, double range1, double range2)
        {
            this.Name = name;
            this.HighestHeartRate = high;
            this.LowestHeartRate = low;
            this.AvgHeartRate = avg;
            this.Range1 = range1;
            this.Range2 = range2;
        }


        public userChart(string name, string email, int high, int low, float avg, double range1, double range2)
        {
            this.Name = name;
            this.HighestHeartRate = high;
            this.LowestHeartRate = low;
            this.AvgHeartRate = avg;
            this.Email = email;
            this.Range1 = range1;
            this.Range2 = range2;
        }



    }
}
