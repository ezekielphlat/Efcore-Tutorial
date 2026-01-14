using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestConsole.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } // Primary key
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public long EmpSalary { get; set; }
        // One to One relationship with EmployeeDetails
        public EmployeeDetails EmployeeDetails { get; set; } // Reference navigation to dependent

        // One to Many relationship with Manager
        public int ManagerId { get; set; } // Foreign key to Manager
        public Manager Manager { get; set; } // Reference navigation property

        // Many to Many relationship with Project via EmployeeProject
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } // collection navigation properties


    }
}
