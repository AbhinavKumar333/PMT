using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace PlanMyTripWebAPI.Controllers
{
    public class SearchController : ApiController
    {
        private PlanMyTripDAL.PMTRepository Repo = null;

        [Route("Search/GetHotels/{city}")]
        public JsonResult<List<PlanMyTripDAL.uspSearchHotels_Result>> GetHotels(string city)
        {
            Repo = new PlanMyTripDAL.PMTRepository();
            List<PlanMyTripDAL.uspSearchHotels_Result> hotelList = Repo.SearchHotels(city);
            JsonResult<List<PlanMyTripDAL.uspSearchHotels_Result>> jsonList = Json<List<PlanMyTripDAL.uspSearchHotels_Result>>(hotelList);
            return jsonList;
        }

        [Route("Search/GetFlights/{origin}/{destination}/{date}")]
        public JsonResult<List<PlanMyTripDAL.usp_SearchFlights1_Result>> GetFlights(string origin,string destination,DateTime date)
        {
            Repo = new PlanMyTripDAL.PMTRepository();
            List<PlanMyTripDAL.usp_SearchFlights1_Result> flightList = Repo.SearchFlight(origin, destination, date);
            return Json<List<PlanMyTripDAL.usp_SearchFlights1_Result>>(flightList);
        }
    }
}
