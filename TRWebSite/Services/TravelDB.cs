using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TRWebSite.Models;

namespace TRWebSite.Services
{
    public class TravelDB
    {

        public mdlTrip trip;

        private ILogger _logger;
        private readonly IConfiguration _configuration;

        public TravelDB(ILogger logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> SaveTrip()
        {
            bool saveSuccess = false;

            //temp commented out for testing
            //var geo = new GEO(_logger, _configuration);
            //if (geo.CalcTravelDistance(trip.startPoint, trip.endPoint))
            //{
            //    trip.travelDistance = geo.travelDistance;
            //    trip.googleTravelTime = geo.travelTime;
            //    trip.startPoint.address = geo.fromAddress;
            //    trip.endPoint.address = geo.toAddress;
            //}
            trip.travelDistance = 84896;
            trip.googleTravelTime = 3991;
            trip.startPoint.address = "202 Albert St, Brisbane City QLD 4000, Australia";
            trip.endPoint.address = "5 Martingale Cct, Clear Island Waters QLD 4226, Australia";

            trip.travelTime = calcTravelTime();

            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("TravelDB")))
            {
                try
                {
                    cnn.Open();
                    var sSQL = " insert  into [Trips] ([userNumber], [userName], [travelDate],";
                    sSQL += "[travelDistance], [travelTime], [GoogleTravelTime],";
                    sSQL += "[start_latitude],[start_longitude],[start_date],[start_address],";
                    sSQL += "[end_latitude],[end_longitude],[end_date],[end_address]";
                    sSQL += ") values (";
                    sSQL += $"{trip.userNumber}, '{SQLEscape(trip.userName)}', '{trip.travelDate}',";
                    sSQL += $"{trip.travelDistance}, {trip.travelTime}, {trip.googleTravelTime},";
                    sSQL += $"{trip.startPoint.latitude}, {trip.startPoint.longitude}, '{trip.startPoint.tpDate}', '{trip.startPoint.address}',";
                    sSQL += $"{trip.endPoint.latitude}, {trip.endPoint.longitude}, '{trip.endPoint.tpDate}', '{trip.endPoint.address}'";
                    sSQL += ")";
                    SqlCommand cmd1 = new SqlCommand(sSQL);
                    cmd1.Connection = cnn;
                    await cmd1.ExecuteNonQueryAsync();
                    saveSuccess = true;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error saving to database: {e.Message}");
                }

            }
            return saveSuccess;
        }

        private int calcTravelTime()
        {
            DateTime start, end;
            DateTime.TryParse(trip.startPoint.tpDate, out start);
            DateTime.TryParse(trip.endPoint.tpDate, out end);
            TimeSpan span = end - start;
            return (int)span.TotalMinutes;
        }

        private string SQLEscape(string raw)
        {
            raw = raw ?? string.Empty;
            string escapedChar = raw.Replace("'", "''");
            return escapedChar;
        }

    }
}
