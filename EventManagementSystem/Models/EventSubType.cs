using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventSubType
    {
        public int EventSubTypeID { get; set; }

        [Required(ErrorMessage = "This field mustn't be empty")]
        public string EventSubTypeName { get; set; }

        [Display(Name = "Event")]
        public int EventTypeID { get; set; }  //foreign key

        public virtual EventType EventType { get; set; }
        public virtual ICollection<EventRequest> EventRequests { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }

    }
}