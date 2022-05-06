using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATP.Exam.Models
{
    [Table(name: "Project", Schema = "Exam")]
    public class Project
    {
        [Key]
        public Guid? projectId { get; set; }
        public string title { get; set; }
        public DateTime dateInit { get; set; }
        public DateTime dateEnd { get; set; }
        public decimal cost { get; set; }
        public string month { get; set; }
        public DateTime? createdDate { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmloyees { get; set; }
    }
}
