using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string FlightName { get; set; }
        public int SeatsCapacity { get; set; }
        public int NoOfSeatsAvailable { get; set; }
    }
}