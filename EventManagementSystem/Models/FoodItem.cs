using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class FoodItem
    {
        //FoodItem
        public int FoodItemID { get; set; }

        [Display(Name = " Item Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Food Category")]
        public int FoodCategoryID { get; set; }//foreing key

        public string MealType { get; set; }

        [DataType(DataType.Currency)]
        public double Cost { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual FoodCategory FoodCategory { get; set; }
    }
}