using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATP.Exam.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid? employeeId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime entryDate { get; set; }
        public string job { get; set; }
        public decimal salary { get; set; }
    }
}
