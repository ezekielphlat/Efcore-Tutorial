using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestConsole.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeDetailId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int EmployeeId { get; set; } // Foreign key to Employee (one to one relationship)
        public Employee Employee { get; set; } // Reference navigation property
    }
}
