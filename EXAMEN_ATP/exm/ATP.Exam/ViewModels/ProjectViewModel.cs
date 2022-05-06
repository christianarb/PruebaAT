using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATP.Exam.ViewModels
{
    public class ProjectViewModel
    {
        public Guid? projectId { get; set; }
        public string title { get; set; }
        public DateTime dateInit { get; set; }
        public DateTime dateEnd { get; set; }
        public decimal cost { get; set; }
        public string month { get; set; }
    }
}
