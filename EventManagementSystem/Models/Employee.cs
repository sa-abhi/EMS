using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeKey { get; set; }


        [Required(ErrorMessage = "Employee Name must be Required")]
        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [StringLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime JoiningDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [StringLength(500)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public bool IsActive { get; set; }

        [Display(Name ="Designation")]
        public int DesignationID { get; set; }

        public string UserName { get; set; }

        public virtual Designation Designation { get; set; }

    }
}