using Assignment.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.IService
{
    public interface IUniversityService
    {

        IList<University> GetUniversities();

        University GetUniversity(int id);
    }
}
