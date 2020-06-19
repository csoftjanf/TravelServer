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
