using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TRWebSite.Models;
using TRWebSite.Services;

namespace TRWebSite.Controllers
{
    public class TripAPIController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public TripAPIController(ILogger<TripAPIController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("TripAPI/SaveTrip")]
        public async Task<mdlTrip> SaveTrip([FromBody] mdlTrip trip)
        {
            var travelDB = new TravelDB(_logger, _configuration);
            travelDB.trip = trip;
            await travelDB.SaveTrip();
            return travelDB.trip;
        }

    }
}




//[HttpGet]
//[ProducesResponseType(StatusCodes.Status200OK)]
//[ProducesResponseType(StatusCodes.Status404NotFound)]
//[Route("TripAPI/getTrip")]
//public async Task<mdlTrip> getTrip(int id)
//{
//    var trip = new mdlTrip();

//    return trip;
//}


//[HttpGet]
//[ProducesResponseType(StatusCodes.Status200OK)]
//[ProducesResponseType(StatusCodes.Status404NotFound)]
//[Route("TripAPI/getTravel")]
//public async System.Threading.Tasks.Task<mdlTrip> getTravel()
//{
//    var trip = new mdlTrip
//    {
//        userNumber = 1,
//        userName = "jan",
//        travelDate = DateTime.Now.ToString("yyyy/mm/dd"),
//        travelDistance = 0,
//        travelTime = 0,
//        startPoint = new mdlTravelPoint
//        {
//            latitude = 1,
//            longitude = 1,
//            tpDate = DateTime.Now.ToString("yyyy/mm/dd")
//        },
//        endPoint = new mdlTravelPoint
//        {
//            latitude = 2,
//            longitude = 2,
//            tpDate = DateTime.Now.ToString("yyyy/mm/dd")
//        }
//    };

//    return trip;
//}