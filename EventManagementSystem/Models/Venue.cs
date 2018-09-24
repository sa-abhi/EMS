using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Venue
    {
        public int VenueID { get; set; }

        [Required(ErrorMessage = "Name must be Required")]
        [MinLength(10, ErrorMessage = "Must be 10 character long")]
        public string VenueName { get; set; }

        [Display(Name = "City")]
        public int CityID { get; set; }  //foreign key

        
        [Display(Name = "Area")]
        public int AreaID { get; set; } //foreign key

        [Required(ErrorMessage ="Address must be Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number must be Required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email must be Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int SeatCapacity { get; set; }
        public bool AirConditioned { get; set; }
        
        [DataType(DataType.Currency)]
        public double Rent { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [Display(Name = "Availablity")]
        public bool IsActive { get; set; }

        public virtual City City { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<EventRequest> EventRequests { get; set; }
        public virtual ICollection<EventSchedule> EventSchedules { get; set; }


    }
}