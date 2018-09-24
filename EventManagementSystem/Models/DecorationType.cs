using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class DecorationType
    {
        public int DecorationTypeID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<DecorationImage> DecorationImages { get; set; }
    }
}