using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Service must be Required")]
        [Display(Name = "Services")]
        [MaxLength(50,ErrorMessage ="Must not cross 50 character")]
        public string ServiceName { get; set; }

        //[Required(ErrorMessage = "Input something is Required")]
        [StringLength(100,MinimumLength =10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
        public virtual ICollection<EventServices> EventServicess { get; set; }
    }
}