using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string City { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Nullable<int> AvgRoomRent { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Email { get; set; }
    }
}