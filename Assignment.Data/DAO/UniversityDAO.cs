using Assignment.Data.IDAO;
using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.DAO
{
    public class UniversityDAO : IUniversityDAO
    {
        public void AddApplicationToCollection(AssignmentContext context, Application application, University university)
        {
            if (university.Applications == null)
            {
                university.Applications = new List<Application>();
            }
            university.Applications.Add(application);

            context.SaveChanges();
        }

        public IList<University> GetUniversities(AssignmentContext context)
        {
            return context.Universities.Include(uni => uni.Applications).ToList();
        }

        public University GetUniversity(AssignmentContext context, int id)
        {
            return context.Universities.Find(id);
        }
    }
}
