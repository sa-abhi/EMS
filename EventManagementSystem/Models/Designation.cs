using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Designation
    {
        public int DesignationID { get; set; }

        [Display(Name ="Designation")]
        [Required(ErrorMessage ="Designation Name is Required")]
        public string DesignationName { get; set; }

        [DataType(DataType.Currency)]
        public decimal BasicSalary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}