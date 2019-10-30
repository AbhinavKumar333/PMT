using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Hotel
    {[Required]
        public int HotelId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Nullable<int> AvgRoomRent { get; set; }
        [Required, MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        public Nullable<int> Rating { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public List<Models.Airport> airports { get; set; }
    }
}