using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class ServiceProvider
    {
        public int ServiceProviderID { get; set; }
        public string ServiceProviderKey { get; set; }


        [Required(ErrorMessage = "Name must be Required")]
        public string ServiceProviderName { get; set; }

        [Required(ErrorMessage = "City must be Required")]
        public string CityID { get; set; }

        [Required(ErrorMessage = "Address must be Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number must be Required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email must be Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Service")]
        public int ServiceID { get; set; } //foreign key
        public virtual Service Service { get; set; }
        public virtual City City { get; set; }

    }
}