using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class ClientFeedback
    {
        public int ClientFeedbackID { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime FeedbackDate { get; set; }

        public string Message { get; set; }

    }
}