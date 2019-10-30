using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Airport
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}