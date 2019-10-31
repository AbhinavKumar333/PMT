using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Flight
    {   [Required (ErrorMessage = "Enter the Details")]
        public string FlightNumber { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string FlightName { get; set; }
        [Required(ErrorMessage = "Enter the Total Numbers of Seats")]
        public int SeatsCapacity { get; set; }
        [Required(ErrorMessage = "Enter the Seats Available")]
        public int NoOfSeatsAvailable { get; set; }

        public List<Models.Hotel> hotelList { get; set; }
    }
}