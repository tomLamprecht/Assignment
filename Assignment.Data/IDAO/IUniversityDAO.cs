using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.IDAO
{
    public interface IUniversityDAO
    {
        public void AddApplicationToCollection(AssignmentContext context, Application application, University university);

        public University GetUniversity(AssignmentContext context, int id);

        IList<University> GetUniversities(AssignmentContext context);

    }
}
