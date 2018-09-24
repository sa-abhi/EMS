using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class EventPayment
    {
        public int EventPaymentID { get; set; }

        [Display(Name = "Client Order")]
        public int ClientOrderID { get; set; }  // foreign key ClientOrderTable

        [DataType(DataType.Currency)]
        public double Total { get; set; }

        [DataType(DataType.Currency)]
        public double PaidAmount { get; set; }

        [DataType(DataType.Currency)]
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Due { get { return(Total - PaidAmount); } }

        public bool PaymentStatus { get; set; }

        public virtual ClientOrder ClientOrder { get; set; }
    }
}