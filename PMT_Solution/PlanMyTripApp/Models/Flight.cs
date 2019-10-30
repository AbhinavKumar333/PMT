using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Flight
    {   [Required ]
        public string FlightNumber { get; set; }
        [Required]
        public string FlightName { get; set; }
        [Required]
        public int SeatsCapacity { get; set; }
        [Required]
        public int NoOfSeatsAvailable { get; set; }

        public List<Models.Hotel> hotelList { get; set; }
    }
}