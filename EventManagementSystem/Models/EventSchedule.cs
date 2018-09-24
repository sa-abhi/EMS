using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    //This table data will be inserted from client order form.

    public class EventSchedule
    {
        public int EventScheduleID { get; set; }
        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public int VenueID { get; set; } //Venue Table
        public string Description { get; set; }
        public string Color { get; set; }
        public bool isFullDay { get; set; }

        public virtual Venue Venue { get; set; }
    }
}