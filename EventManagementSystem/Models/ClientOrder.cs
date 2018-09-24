using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class ClientOrder
    {
        public int ClientOrderID { get; set; }

        [Display(Name = "Client")]
        [Required]
        public int ClientID { get; set; }  //Client Table

        [Display(Name = "City")]
        [Required]
        public int CityID { get; set; } //City Table

        [Display(Name = "EventType")]
        [Required]
        public int EventTypeID { get; set; }  //Category Table

        [Display(Name = "EventSubType")]
        [Required]
        public int EventSubTypeID { get; set; } //Subcategory Table

        [Required(ErrorMessage = "Event Name is Required")]
        [Display(Name = "Event")]
        public string EventName { get; set; }

        public DateTime EventStartDate { get; set; }

        public DateTime EventEndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Date
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        [Display(Name = "Venue")]
        public int VenueID { get; set; } //Venue Table
        public int NoOfGuest { get; set; }
        public string SpecialInstruction { get; set; }

        public virtual Client Client { get; set; }
        public virtual City City { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual EventSubType EventSubType { get; set; }
        public virtual Venue Venue { get; set; }

        public virtual ICollection<EventsCatering> EventsCaterings { get; set; }
        public virtual ICollection<EventBill> EventBills { get; set; }
        public virtual ICollection<EventPayment> EventPayments { get; set; }
     
        public virtual ICollection<EventsCinematography> EventsCinematographies { get; set; }
        public virtual ICollection<EventsDecoration> EventsDecorations { get; set; }
        public virtual ICollection<EventServices> EventServicess { get; set; }
        public virtual ICollection<EventsPhotography> EventsPhotographies { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}