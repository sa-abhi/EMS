using EventManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.ViewModels
{
    public class ClientOrderViewModel
    {
        public int ClientOrderID { get; set; }
        public int ClientID { get; set; }  //Client Table     
        public string FirstName { get; set; } // new properties added
        public string LastName { get; set; } // new properties added
        public int CityID { get; set; } //City Table   
        public string CityName { get; set; }  // new properties added
        public int EventTypeID { get; set; }  //Category Table    
        public string EventTypeName { get; set; }  // new properties added
        public int EventSubTypeID { get; set; } //Subcategory Table
        public string EventSubTypeName { get; set; }   // new properties added
        public string EventName { get; set; }
        //[DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime EventStartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime EventEndDate { get; set; }
        //public DateTime EventTime { get; set; }
        public int? VenueID { get; set; } //Venue Table
        public string VenueName { get; set; } // new properties added
        public int NoOfGuest { get; set; }
        public string SpecialInstruction { get; set; }
        public int EventScheduleID { get; set; }
        public int EventServicesID { get; set; }

        public int ServiceID { get; set; } // foreign key ServiceType
        public int ServiceProviderID { get; set; }
        //public double? Price { get; set; }
        public double Rent { get; set; }
        //public int MyProperty { get; set; }

        public List<EventServices> EventServicess { get; set; }

        public List<EventsCatering> EventsCaterings { get; set; }

        public List<EventsDecoration> EventsDecorations { get; set; }

        public int? EventsPhotographyID { get; set; }
        [Display(Name = "Category")]
        public int? PgCategory { get; set; }
        [Display(Name = "Number Of Team")]
        public int? PgNumberOfTeam { get; set; }
        public System.Nullable<double> PgPrice { get; set; }

        public System.Nullable<double> TotalCateCost { get; set; }
        public System.Nullable<double> TotalDecCost { get; set; }


        public int? DecorationImageID { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase decImageUpload { get; set; }

        //public int? DecorationTypeID { get; set; }
        public string Name { get; set; }
        public double SubTotalAmmount { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }
        public double NetTotal { get; set; }



    }
}