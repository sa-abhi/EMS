using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventRequest
    {
        public int EventRequestID { get; set; }

        [Display(Name = "Client")]
        public int ClientID { get; set; } //Foreign key

        [Display(Name = "City")]
        public int CityID { get; set; } //Foreign key

        [Display(Name = "Area")]
        public int AreaID { get; set; }  //Foreign key

        [Display(Name = "EventType")]
        public int EventTypeID { get; set; } //Foreign key

        [Display(Name = "EventSubType")]
        public int EventSubTypeID { get; set; }  //Foreign key

        [Required(ErrorMessage = "Event Name must be Required")]
        [Display(Name = "Event")]
        public string EventName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name = "Venue")]
        public int VenueID { get; set; }  //Foreign key

        [Required]
        [DataType(DataType.Duration)]
        public string Duration { get; set; }

        [Required]
        public int NoOfGuest { get; set; }

        [DataType(DataType.Duration)]
        public double Budget { get; set; }

        public bool isSeen { get; set; }


        //Please give us some basic idea about your requirement (Choose only that you want)
        public bool Stage { get; set; }
        public bool Catering { get; set; }
        public bool SoundSystemAndMusic { get; set; }
        public bool Decoration { get; set; }
        public bool PhotographyAndCinematography { get; set; }
        public bool Invitation { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string SpecialInstruction { get; set; }

        public virtual Client Client { get; set; }
        public virtual City City { get; set; }
        public virtual Area Area { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventSubType EventSubType { get; set; }
        public virtual Venue Venue { get; set; }
    }
}