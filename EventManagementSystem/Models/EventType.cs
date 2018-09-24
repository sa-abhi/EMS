using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventType
    {
        public int EventTypeID { get; set; }

        [Required(ErrorMessage ="Event field mustn't be empty")]
        [Display(Name ="Event")]
        public string EventTypeName { get; set; }

        public virtual ICollection<EventSubType> EventSubTypes { get; set; }
        public virtual ICollection<EventRequest> EventRequest { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}