using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace PlanMyTripDAL
{
    public class PMTRepository
    {
        PlanMyTripDBEntities planMyTripDBContext = null;
        public PMTRepository()
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
        }
        public PMTRepository(PlanMyTripDBEntities context)
        {
            planMyTripDBContext = context;
        }
        //-------------------------------User Operations
        public bool AddUser(User userEnt)
        {
            planMyTripDBContext.Users.Add(userEnt);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public bool DeleteUser(int usrId)
        {
            User tuser = planMyTripDBContext.Users.Find(usrId);
            planMyTripDBContext.Users.Remove(tuser);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public bool UpdateUser(User user)
        {
            User tuser = planMyTripDBContext.Users.Find(user.UserId);
            tuser.UserId = user.UserId;
            tuser.FirstName = user.FirstName;
            tuser.LastName = user.LastName;
            tuser.Password = user.Password;
            tuser.EmailId = user.EmailId;
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public int ValidateUser(string emailId,string password)
        {
            List<User> result = (from c in planMyTripDBContext.Users
                          where c.EmailId == emailId && c.Password == password select c).ToList();
            if (result.Count > 0) { return result.Count; }
            else { return -1; }
        }
        public List<User> ViewAll()
        {
            return planMyTripDBContext.Users.ToList();
        }
        public User View(int id)
        {
            return planMyTripDBContext.Users.Find(id);
        }
        public User ViewUserByEmail(string email)
        {
            var u = (from c in planMyTripDBContext.Users where c.EmailId == email select c).ToList();
            return u.FirstOrDefault();
        }

        //--------------------------------------Hotel Operations

        public bool AddHotel(Hotel hotel)
        {
            planMyTripDBContext.Hotels.Add(hotel);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }

        }
        public List<Hotel> ViewHotels()
        {
            List<Hotel> hotelList = planMyTripDBContext.Hotels.ToList();
            return hotelList;
        }
        public Hotel GetHotel(int hotelId)
        {
            var hotelSingle = planMyTripDBContext.Hotels.Find(hotelId);
            return hotelSingle;
        }
        public bool UpdateHotel(Hotel hotel)
        {
            Hotel hotelup = planMyTripDBContext.Hotels.Find(hotel.HotelId);
            hotelup.HotelId = hotel.HotelId;
            hotelup.HotelName = hotel.HotelName;
            hotelup.Phone = hotel.Phone;
            hotelup.Rating = hotel.Rating;
            hotelup.City = hotel.City;
            hotelup.Address = hotel.Address;
            hotelup.Description = hotel.Description;
            hotelup.AvgRoomRent = hotel.AvgRoomRent;
            hotelup.Email = hotel.Email;
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0)
            { return true; }
            else { return false; }

        }
        public bool DeleteHotel(int hotelId)
        {
            Hotel hotelDel = planMyTripDBContext.Hotels.Find(hotelId);
            planMyTripDBContext.Hotels.Remove(hotelDel);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }

        }

        //----------------------------------Flight Operations

        public bool AddFlight(Flight flight)
        {
            planMyTripDBContext.Flights.Add(flight);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Flight GetFlight(string flightNo)
        {
            Flight tflight = planMyTripDBContext.Flights.Find(flightNo);
            int result = planMyTripDBContext.SaveChanges();
            return tflight;
        }
        public bool UpdateFlight(Flight flight)
        {
            Flight tflight = planMyTripDBContext.Flights.Find(flight.FlightNumber);
            tflight.FlightNumber = flight.FlightNumber;
            tflight.FlightName = flight.FlightName;
            tflight.SeatsCapacity = flight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;

            int result = planMyTripDBContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteFlight(string FlightNumber)
        {
            Flight tflight = planMyTripDBContext.Flights.Find(FlightNumber);
            planMyTripDBContext.Flights.Remove(tflight);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Flight> ViewFlights()
        {
            List<Flight> flightList = planMyTripDBContext.Flights.ToList();
            return flightList;
        }
        public List<uspSearchHotels_Result> SearchHotels(string city)
        {
            List<uspSearchHotels_Result> hotelList = planMyTripDBContext.uspSearchHotels(city).ToList();
            return hotelList;
        }
        public List<Airport> GetAirports()
        {
            return planMyTripDBContext.Airports.ToList();
        }
        public List<usp_SearchFlights1_Result> SearchFlight(string origin,string destination,DateTime date)
        {
            List<usp_SearchFlights1_Result> flightList = planMyTripDBContext.usp_SearchFlights1(origin, destination, date).ToList();
            return flightList;
        }
    }
}
