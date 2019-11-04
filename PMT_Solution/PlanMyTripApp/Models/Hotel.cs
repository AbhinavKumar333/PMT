using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Enter the City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter the  Name")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "Enter the Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter the Details")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the AvgRoomRent")]
        public Nullable<int> AvgRoomRent { get; set; }
        [Required, MaxLength(10)]
        public string Phone { get; set; }
        [Required][Range(0,7)]
        public Nullable<int> Rating { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public List<Models.Airport> airports { get; set; }
    }
}