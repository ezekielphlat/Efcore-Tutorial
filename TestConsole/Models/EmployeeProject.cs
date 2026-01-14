using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } // Reference navigation property

        public int ProjectId { get; set; }
        public Project Project { get; set; } // Reference navigation property
    }
}
