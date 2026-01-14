using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestConsole.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } // collection navigation properties
    }
}
