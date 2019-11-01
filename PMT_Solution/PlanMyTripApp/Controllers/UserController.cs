﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanMyTripApp.Controllers
{
    public class UserController : Controller
    {
        PlanMyTripDAL.PMTRepository pmtRepo = null;
        public UserController()
        {
            pmtRepo = new PlanMyTripDAL.PMTRepository();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Models.User u)
        {
            PlanMyTripDAL.User temp = new PlanMyTripDAL.User();
            temp.UserId = u.UserId;
            temp.FirstName = u.FirstName;
            temp.EmailId = u.EmailId;
            temp.LastName = u.LastName;
            temp.Password = u.Password;
            if (ModelState.IsValid)
            { 
                bool result = pmtRepo.AddUser(temp);
                if (result) { ViewBag.Msg = "User Added Successfully!"; }
                else { ViewBag.ErrorMsg = "Error occured while adding user"; }
            }
            return View("AddUser");
        }
        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            List<PlanMyTripDAL.User> dal = pmtRepo.ViewAll();
            List<Models.User> mvc = new List<Models.User>();
            foreach (var u in dal)
            {
                Models.User temp = new Models.User();
                temp.UserId = u.UserId;
                temp.FirstName = u.FirstName;
                temp.EmailId = u.EmailId;
                temp.LastName = u.LastName;
                temp.Password = u.Password;
                mvc.Add(temp);
            }
            return View(mvc);
        }
        [HttpGet]
        public ActionResult ViewUser()
        {
            string email = Session["Email"].ToString();
            var dal = pmtRepo.ViewUserByEmail(email);
            Models.User mvc = new Models.User();
            mvc.UserId = dal.UserId;
            mvc.FirstName = dal.FirstName;
            mvc.LastName = dal.LastName;
            mvc.EmailId = dal.EmailId;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            PlanMyTripDAL.User dal = pmtRepo.View(id);
            Models.User mvc = new Models.User();
            mvc.UserId = dal.UserId;
            mvc.FirstName = dal.FirstName;
            mvc.LastName = dal.LastName;
            mvc.EmailId = dal.EmailId;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpPost]
        public ActionResult EditConfirm(Models.User mvc)
        {
            PlanMyTripDAL.User dal = pmtRepo.View(mvc.UserId);
            dal.UserId = mvc.UserId;
            dal.FirstName = mvc.FirstName;
            dal.LastName = mvc.LastName;
            dal.EmailId = mvc.EmailId;
            dal.Password = mvc.Password;
            bool result = pmtRepo.UpdateUser(dal);
            if (result) { ViewBag.Msg = "Updated Successfully!"; }
            else { ViewBag.ErrorMsg = "Update Failed"; }
            return View("EditUser");
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            PlanMyTripDAL.User dal = pmtRepo.View(id);
            Models.User mvc = new Models.User();
            mvc.UserId = dal.UserId;
            mvc.FirstName = dal.FirstName;
            mvc.LastName = dal.LastName;
            mvc.EmailId = dal.EmailId;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteConfirmed(int id)
        {
            pmtRepo.DeleteUser(id);
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        public ActionResult LoginConfirmed(Models.User user)
        {
            //ViewBag.abc = fc[2].ToString();
            //return View("LoginUser");
            if (user.EmailId == null || user.Password == null)
            {
                ViewBag.ErrorMsg = "Empty Fields!";
                return View("LoginUser");
            }
            int result = pmtRepo.ValidateUser(user.EmailId, user.Password);
            if ((result > 0))
            {
                Session["Email"] = user.EmailId;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Msg = "Check Credentials!";
                return View("LoginUser");
            }
        }
        public ActionResult LogoutUser()
        {
            Session.Clear();
            return View("LoginUser");
        }
    }
}