using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestConsole.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string MngFirstName { get; set; }
        public string MngLastName { get; set; }

        // One to Many relationship with Employee
        public ICollection<Employee> Employees { get; set; } // Collection navigation property
    }
}
