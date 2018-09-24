using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventServices
    {
        public int EventServicesID { get; set; }

        [Display(Name = "Client Order")]
        public int ClientOrderID { get; set; } // foreign key ClientOrder

        [Display(Name = "Service Name")]
        public int ServiceID { get; set; } // foreign key ServiceType

        [Display(Name = "Service Provider")]
        public int? ServiceProviderID { get; set; }

        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        [DataType(DataType.Currency)]
        public double? Cost { get; set; }


        public virtual ClientOrder ClientOrder { get; set; }
        public virtual Service Service { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        
    }
}