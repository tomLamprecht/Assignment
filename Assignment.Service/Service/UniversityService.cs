using Assignment.Data.DAO;
using Assignment.Data.IDAO;
using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using Assignment.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Service
{
    public class UniversityService : IUniversityService
    {
        IUniversityDAO universityDAO;

        public UniversityService()
        {
            universityDAO = new UniversityDAO(); 
        }
        public IList<University> GetUniversities()
        {
            using(AssignmentContext context = new AssignmentContext())
            {
                return universityDAO.GetUniversities(context);
            }
        }

        public University GetUniversity(int id)
        {
            using(AssignmentContext ctx = new AssignmentContext())
            {
                return universityDAO.GetUniversity(ctx, id);
            }
        }
    }
}
