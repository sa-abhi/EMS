using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class DecorationImage
    {
        public int DecorationImageID { get; set; }

        public string DecorationImageKey { get; set; }
        public int DecorationTypeID { get; set; }    //foreign

        [StringLength(500)]
        public string Image { get; set; }

        public string ImageCode { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual DecorationType DecorationType { get; set; }
    }
}