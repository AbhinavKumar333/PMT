using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanMyTripApp.Controllers
{
    public class FlightController : Controller
    {
        private PlanMyTripDAL.PMTRepository pmtRepo = null;
        // GET: Flight
        public FlightController()
        {
            pmtRepo = new PlanMyTripDAL.PMTRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddFlight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFlight(Models.Flight flight)
        {
            PlanMyTripDAL.Flight tflight = new PlanMyTripDAL.Flight();
            tflight.FlightNumber = flight.FlightNumber;
            tflight.FlightName = flight.FlightName;
            tflight.SeatsCapacity = flight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
            bool result = pmtRepo.AddFlight(tflight);
            if (result)
            {
                ViewBag.Msg = "Flight Registered";
            }
            else
            {
                ViewBag.ErrMsg = "Registration Failed !!!";
            }
            return View("AddFlight", flight);

        }
        [HttpGet]
        public ActionResult UpdateFlight(string flightNo)
        {
            PlanMyTripDAL.Flight flight = pmtRepo.GetFlight(flightNo);
            Models.Flight tflight = new Models.Flight();
            tflight.FlightNumber = flight.FlightNumber;
            tflight.FlightName = flight.FlightName;
            tflight.SeatsCapacity = flight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
            return View(tflight);
        }
        [HttpPost]
        public ActionResult UpdateFlight(Models.Flight flight)
        {
            PlanMyTripDAL.Flight tflight = new PlanMyTripDAL.Flight();
            tflight.FlightNumber = flight.FlightNumber;
            tflight.FlightName = flight.FlightName;
            tflight.SeatsCapacity = flight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
            bool result = pmtRepo.UpdateFlight(tflight);
            if (result)
            {
                ViewBag.Msg = "Flight Updated";
            }
            else
            {
                ViewBag.ErrMsg = "Flight Update Failed!!";
            }
            return View("UpdateFlight", flight);
        }

        public ActionResult ViewFlight(string flightNo)
        {
            PlanMyTripDAL.Flight flight = pmtRepo.GetFlight(flightNo);
            Models.Flight tflight = new Models.Flight();
            tflight.FlightNumber = flight.FlightNumber;
            tflight.FlightName = flight.FlightName;
            tflight.SeatsCapacity = flight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
            return View(tflight);
        }
        public ActionResult ViewFlights()
        {
            List<PlanMyTripDAL.Flight> flightList = pmtRepo.ViewFlights();
            List<Models.Flight> tflightList = new List<Models.Flight>();
            foreach (var flight in flightList)
            {
                Models.Flight tflight = new Models.Flight();
                tflight.FlightNumber = flight.FlightNumber;
                tflight.FlightName = flight.FlightName;
                tflight.SeatsCapacity = flight.SeatsCapacity;
                tflight.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
                tflightList.Add(tflight);
            }
            return View(tflightList);

        }
        [HttpGet]
        public ActionResult DeleteFlight(string flightNo)
        {
            PlanMyTripDAL.Flight sflight = pmtRepo.GetFlight(flightNo);
            Models.Flight tflight = new Models.Flight();
            tflight.FlightNumber = sflight.FlightNumber;
            tflight.FlightName = sflight.FlightName;
            tflight.SeatsCapacity = sflight.SeatsCapacity;
            tflight.NoOfSeatsAvailable = sflight.NoOfSeatsAvailable;
            return View(tflight);
        }
        [HttpPost]
        public ActionResult DeleteFlightConfirm(string FlightNumber)
        {
            bool result = pmtRepo.DeleteFlight(FlightNumber);
            return RedirectToAction("ViewFlights");
        }
        [HttpGet]
        public ActionResult GetSearchResult()
        {
            var dal = pmtRepo.GetAirports();
            Models.Hotel mvc = new Models.Hotel();
            mvc.airports = new List<Models.Airport>();
            foreach(var d in dal)
            {
                Models.Airport t = new Models.Airport();
                t.AirportCode = d.AirportCode;
                t.AirportName = d.AirportName;
                t.Description = d.Description;
                t.Location = d.Location;
                mvc.airports.Add(t);
            }
            return View(mvc);
        }
        [HttpPost]
        public ActionResult GetSearchResult(FormCollection fc)
        {
            return View();
        }
    }
}