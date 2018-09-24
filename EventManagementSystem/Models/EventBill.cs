using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventBill
    {
        public int EventBillID { get; set; }


        [Display(Name = "Client Order")]
        public int ClientOrderID { get; set; }  // foreign key ClientOrder table

        [DataType(DataType.Currency)]
        public double SubTotalAmount { get; set; }

        [DataType(DataType.Currency)]
        public double? vat { get; set; }

        [DataType(DataType.Currency)]
        public int? Discount { get; set; }

        [DataType(DataType.Currency)]
        public double? Total { get { return (SubTotalAmount + vat - Discount); } }
        public string MadeBy { get; set; }
        public virtual ClientOrder ClientOrder { get; set; }
    }
}