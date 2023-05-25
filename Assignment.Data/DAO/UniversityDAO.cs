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
            context.Universities.Include(uni => uni.Applications).ToList();
            return context.Universities.Find(id);
        }

        public University GetUniversity(AssignmentContext context, Application application)
        {
            IList<University> uniList = context.Universities.Include(uni => uni.Applications).ToList();
            foreach (var uni in uniList)
            {
                if(uni.Applications.Any(app => app.ApplicationId == application.ApplicationId))
                {
                    return uni;
                }
            }
            return null;
        }

        public void RemoveApplicationFromCollection(AssignmentContext context, Application application, University university)
        {
            //Make super duper sure to prevent lazy loading ...
            university = GetUniversity(context, university.UniversityId);

            if (university.Applications != null) {
                university.Applications.Remove(application);
                context.SaveChanges();
            }
        }
    }
}
