using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATP.Exam.ViewModels
{
    public class ProjectEmployeeViewModel
    {
        public Guid? projectEmployeeId { get; set; }
        public Guid projectId { get; set; }
        public Guid employeeId { get; set; }
        public string role { get; set; }
    }
}
