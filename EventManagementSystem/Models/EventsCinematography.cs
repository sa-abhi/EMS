using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class EventsCinematography
    {
        public int EventscinematographyID { get; set; }
        public int ClientOrderID { get; set; }   //foreign key
        public int NumberOfTeaM { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public virtual ClientOrder ClientOrders { get; set; }
    }
}