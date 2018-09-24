using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceKey { get; set; }
        
        public int ClientOrderID { get; set; }  // foreign key
        
        public string PaymentType { get; set; }

        [DataType(DataType.Currency)]
        public double PaidAmount { get; set; }

        public string MadeBy { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public virtual ClientOrder ClientOrder { get; set; }
    }
}