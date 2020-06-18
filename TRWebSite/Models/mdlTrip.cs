using System;
using System.Collections.Generic;

namespace TRWebSite.Models
{
    public class mdlTrip
    {
        public int userNumber { get; set; }
        public string userName { get; set; }
        public string travelDate { get; set; }
        public double travelDistance { get; set; }
        public double travelTime { get; set; }
        public double googleTravelTime { get; set; }
        public mdlTravelPoint startPoint { get; set; }
        public mdlTravelPoint endPoint { get; set; }
    }

    public class mdlTravelPoint
    {
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string tpDate { get; set; }
    }

    public class mdlTravelResults
    {
        public int userNumber { get; set; }
        public string userName { get; set; }
        public List<mdlTripResults> trips { get; set; }
    }

    public class mdlTripResults
    {
        public DateTime travelDate { get; set; }
        public decimal travelDistance { get; set; }
        public decimal travelTime { get; set; }
    }
}
