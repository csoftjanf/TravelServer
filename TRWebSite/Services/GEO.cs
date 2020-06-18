using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using TRWebSite.Models;

namespace TRWebSite.Services
{
    public class GEO
    {
        public string fromAddress { get; set; }
        public string toAddress { get; set; }
        public double travelDistance { get; set; } = 0;
        public double travelTime { get; set; } = 0;

        private readonly IConfiguration _configuration;
        private ILogger _logger;

        public GEO(ILogger logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public bool CalcTravelDistance(mdlTravelPoint start, mdlTravelPoint end)
        {
            var apiKey = _configuration["GoogleAPIKey"]; 
            var baseURL = _configuration["GoogleBaseURL"]; 

            var source = $"{start.latitude},{start.longitude}";
            var destination = $"{end.latitude},{end.longitude}";
            var travelMode = "Driving";
            var geocodeInfo = string.Empty;

            var urlRequest = $"/json?origins={source}&destinations={destination}&mode='{travelMode}'&sensor=false&key={apiKey}";
            try
            {
                using (var client = new WebClient())
                {
                    string seachurl = baseURL + urlRequest;
                    geocodeInfo = client.DownloadString(seachurl);
                }
                if (!string.IsNullOrEmpty(geocodeInfo))
                {
                    var gResult = JsonConvert.DeserializeObject<GoogleMatrix>(geocodeInfo);
                    if (gResult != null)
                    {
                        if (gResult.origin_addresses.Count() > 0)
                            fromAddress = gResult.origin_addresses[0];

                        if (gResult.destination_addresses.Count() > 0)
                            toAddress = gResult.destination_addresses[0];

                        if (gResult.rows.Count() > 0)
                        {
                            if (gResult.rows[0].elements[0].status == "OK")
                            {
                                travelDistance = gResult.rows[0].elements[0].distance.value;
                                travelTime = gResult.rows[0].elements[0].duration.value;
                            }
                        }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"google error :{ex.Message}");
                return false;
            }
        }
    }
}
