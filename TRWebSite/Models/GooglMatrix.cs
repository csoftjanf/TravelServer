namespace TRWebSite.Models
{
    public class GoogleMatrix
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }

        public Rows[] rows { get; set; }
    }

    public class Rows
    {
        public Elements[] elements { get; set; }
    }

    public class Elements
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}
