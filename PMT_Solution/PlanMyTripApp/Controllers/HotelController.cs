﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PlanMyTripApp.Controllers
{
    public class HotelController : Controller
    {
        private PlanMyTripDAL.PMTRepository pmtRepo = null;
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }
        public HotelController()
        {
            pmtRepo = new PlanMyTripDAL.PMTRepository();

        }
        [HttpGet]
        public ActionResult AddHotel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHotel(Models.Hotel modhotel)
        {
            PlanMyTripDAL.Hotel hoteladd = new PlanMyTripDAL.Hotel();
            hoteladd.HotelId = modhotel.HotelId;
            hoteladd.HotelName = modhotel.HotelName;
            hoteladd.Phone = modhotel.Phone;
            hoteladd.Rating = modhotel.Rating;
            hoteladd.Email = modhotel.Email;
            hoteladd.Description = modhotel.Description;
            hoteladd.City = modhotel.City;
            hoteladd.AvgRoomRent = modhotel.AvgRoomRent;
            hoteladd.Address = modhotel.Address;
            if (ModelState.IsValid)
            {
                bool result = pmtRepo.AddHotel(hoteladd);
                if (result) { ViewBag.msg = "Registered Successfully"; }
                else { ViewBag.errormsg = "Registration Failed"; }
            }
            return View("AddHotel", modhotel);

        }
        [HttpGet]
        public ActionResult ViewHotels()
        {
            List<PlanMyTripDAL.Hotel> hotelviews = pmtRepo.ViewHotels();
            List<Models.Hotel> hotelmodels = new List<Models.Hotel>();
            foreach (var item in hotelviews)
            {
                Models.Hotel h = new Models.Hotel();
                h.HotelId = item.HotelId;
                h.HotelName = item.HotelName;
                h.Phone = item.Phone;
                h.Rating = item.Rating;
                h.Email = item.Email;
                h.City = item.City;
                h.Description = item.Description;
                h.Phone = item.Phone;
                h.AvgRoomRent = item.AvgRoomRent;
                hotelmodels.Add(h);
            }
            return View(hotelmodels);
        }

        public ActionResult ViewHotel(int hotelId)
        {
            PlanMyTripDAL.Hotel hotelview = pmtRepo.GetHotel(hotelId);
            Models.Hotel h = new Models.Hotel();
            h.HotelId = hotelview.HotelId;
            h.HotelName = hotelview.HotelName;
            h.Phone = hotelview.Phone;
            h.Rating = hotelview.Rating;
            h.Email = hotelview.Email;
            h.City = hotelview.City;
            h.Description = hotelview.Description;
            h.Phone = hotelview.Phone;
            h.AvgRoomRent = hotelview.AvgRoomRent;
            return View(h);

        }
        [HttpGet]
        public ActionResult EditHotel(int HotelId)
        {
            PlanMyTripDAL.Hotel hoteledit = pmtRepo.GetHotel(HotelId);
            Models.Hotel h = new Models.Hotel();
            h.HotelId = hoteledit.HotelId;
            h.HotelName = hoteledit.HotelName;
            h.Phone = hoteledit.Phone;
            h.Rating = hoteledit.Rating;
            h.Email = hoteledit.Email;
            h.City = hoteledit.City;
            h.Description = hoteledit.Description;
            h.Phone = hoteledit.Phone;
            h.AvgRoomRent = hoteledit.AvgRoomRent;
            return View(h);
        }
        [HttpPost]
        public ActionResult EditHotel(Models.Hotel modHotel)
        {
            PlanMyTripDAL.Hotel h = new PlanMyTripDAL.Hotel();
            h.HotelId = modHotel.HotelId;
            h.HotelName = modHotel.HotelName;
            h.Phone = modHotel.Phone;
            h.Rating = modHotel.Rating;
            h.Email = modHotel.Email;
            h.City = modHotel.City;
            h.Description = modHotel.Description;
            h.Phone = modHotel.Phone;
            h.AvgRoomRent = modHotel.AvgRoomRent;
            bool result = pmtRepo.UpdateHotel(h);
            if (result) { ViewBag.msg = "Updated"; }
            else { ViewBag.errormsg = "Updation Failed"; }
            return View("EditHotel", modHotel);

        }
        [HttpGet]
        public ActionResult DeleteHotel(int hotelId)
        {
            PlanMyTripDAL.Hotel hoteldel = pmtRepo.GetHotel(hotelId);
            Models.Hotel h = new Models.Hotel();
            h.HotelId = hoteldel.HotelId;
            h.HotelName = hoteldel.HotelName;
            h.Phone = hoteldel.Phone;
            h.Rating = hoteldel.Rating;
            h.Email = hoteldel.Email;
            h.City = hoteldel.City;
            h.Description = hoteldel.Description;
            h.Phone = hoteldel.Phone;
            h.AvgRoomRent = hoteldel.AvgRoomRent;
            return View(h);

        }
        [HttpPost]
        public ActionResult DeleteHotelConfirm(int hotelId)
        {
            bool result = pmtRepo.DeleteHotel(hotelId);
            return RedirectToAction("ViewHotels");
        }
        [HttpGet]
        public ActionResult GetSearchResult()
        {
            var dal = pmtRepo.ViewHotels();
            Models.Flight mvc = new Models.Flight();
            mvc.hotelList = new List<Models.Hotel>();
            foreach(var d in dal)
            {
                Models.Hotel t = new Models.Hotel();
                t.Address = d.Address;
                t.Email = d.Email;
                t.Description = d.Description;
                t.HotelId = d.HotelId;
                t.Rating = d.Rating;
                t.HotelName = d.HotelName;
                t.Phone = d.Phone;
                t.AvgRoomRent = d.AvgRoomRent;
                t.City = d.City;
                mvc.hotelList.Add(t);
            }
            return View(mvc);
        }
        [HttpPost]
        public ActionResult GetSearchResult(FormCollection fc)
        {
            List<PlanMyTripDAL.uspSearchHotels_Result> hotelList = new List<PlanMyTripDAL.uspSearchHotels_Result>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62921/");
                var response = client.GetAsync("Search/GetHotels/" + fc[1].ToString());
                var res = response.Result;
                if (res.IsSuccessStatusCode)
                {
                    var GetData = res.Content.ReadAsAsync<List<PlanMyTripDAL.uspSearchHotels_Result>>();
                    hotelList = GetData.Result;
                }
                return View("GetSearchRes",hotelList);
            }
        }
    }
}