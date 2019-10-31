using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class User
    {   [Required(ErrorMessage ="Enter UserId")]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Enter LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Enter Email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Enter password")]
        public string Password { get; set; }
    }
}