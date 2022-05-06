using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATP.Exam.Models
{
    [Table(name: "Employee", Schema = "Exam")]
    public class Employee
    {
        [Key]
        public Guid? employeeId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime entryDate { get; set; }
        public string job { get; set; }
        public decimal salary { get; set; }
        public DateTime? createdDate { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmloyees { get; set; }
    }
}
