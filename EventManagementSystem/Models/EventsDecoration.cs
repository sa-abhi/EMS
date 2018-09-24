using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventsDecoration
    {
        public int EventsDecorationID { get; set; }

        [Display(Name = "Order")]
        public int ClientOrderID { get; set; } //foreing key

        [Display(Name = "Decoration Type")]
        public int DecorationTypeID { get; set; } //foreing key

        //[NotMapped]
        public int? DecorationImageID { get; set; }//foreing key

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        
        public string CustomImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ClientOrder ClientOrder { get; set; }
        public virtual DecorationType DecorationType { get; set; }
        public virtual DecorationImage DecorationImage { get; set; }

    }
}