using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventsPhotography
    {
        public int EventsPhotographyID { get; set; }

        [Display(Name ="Order ID")]
        public int ClientOrderID { get; set; }//foreing key
        public int Category { get; set; }

        [Range(1, 5)]
        public int NumberOfTeam { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public virtual ClientOrder ClientOrder { get; set; }
    }
}