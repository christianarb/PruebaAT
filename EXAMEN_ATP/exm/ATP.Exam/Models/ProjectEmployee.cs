using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATP.Exam.Models
{
    [Table(name: "Project_Employee", Schema = "Exam")]
    public class ProjectEmployee
    {
        [Key]
        public Guid projectEmployeeId { get; set; }
        public Guid projectId { get; set; }
        public Guid employeeId { get; set; }
        public string role { get; set; }
        public DateTime? createdDate { get; set; }

        [ForeignKey("projectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("employeeId")]
        public virtual Employee Employee { get; set; }
    }
}
