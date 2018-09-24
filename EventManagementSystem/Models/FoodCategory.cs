using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class FoodCategory
    {
        //FoodCategory
        public int FoodCategoryID { get; set; }

        [Display(Name = "Name")]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<FoodItem> FoodItems { get; set; }
    }
}