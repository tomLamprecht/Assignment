using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models.Domains
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Application> Applications { get; set; }

    }
}
