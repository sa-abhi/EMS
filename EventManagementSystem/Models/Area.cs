using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Area
    {
        public int AreaID { get; set; }

        [Required(ErrorMessage = "Area field is Required")]
        [Display(Name = "Area")]
        public string AreaName { get; set; }

        [Display(Name = "City")]
        public int CityID { get; set; } //foreign key
        public virtual City City { get; set; }
        
    }
}