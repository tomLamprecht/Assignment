using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Models
{
    public class ApplicationUserUniversity
    {
        public string Course { get; set; }
        public string Statement { get; set; }
        public string TeacherContact { get; set; }

        public string UserId { get; set; }
        public int UniversityId { get; set; }

    }
}
