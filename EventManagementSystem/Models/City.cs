using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class City
    {
        public int CityID { get; set; }

        [Required(ErrorMessage = "City field is Required")]
        [Display(Name = "City")]
        public string CityName { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<EventRequest> EventRequests { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }


    }
}