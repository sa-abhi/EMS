using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class EventsCatering
    {
        //EventsCatering
        public int EventsCateringID { get; set; }

        [Display(Name ="order")]
        public int ClientOrderID { get; set; }  // foreign key

        [Display(Name = "Meal")]
        [StringLength(30)]
        public string MealType { get; set; }

        [Display(Name = "Items")]
        [StringLength(30)]
        public string FoodItems { get; set; }

        public double PerPersonCost { get; set; }

        [DataType(DataType.Currency)]
        public double TotalCost { get; set; }

        public virtual ClientOrder ClientOrder { get; set; }
    }
}