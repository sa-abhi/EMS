using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientKey { get; set; }


        [Required(ErrorMessage ="Name is Required")]
        [StringLength(30)]
        public string Name { get; set; }



        [StringLength(50)]
        public string Organization { get; set; }

        
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name ="City")]
        public int? CityID { get; set; } //Foreign key

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone is Required")]
        [StringLength(14)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        
        public string UserName { get; set; }


        public virtual ICollection<EventRequest> EventRequests { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }

        public virtual City City { get; set; }

    }
}