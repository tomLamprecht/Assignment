using Assignment.Data.IDAO;
using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        public void AddApplication(AssignmentContext context, Application application)
        {
            context.Applications.Add(application);
        }

        public void DeleteApplication(AssignmentContext context, Application application)
        {
            context.Applications.Remove(application);

            context.SaveChanges();
        }

        public Application GetApplication(AssignmentContext context, int id)
        {
            return context.Applications.Find(id);
        }

 

        public void SetFirm(AssignmentContext context, int applicationId, bool firm)
        {
            Application application = GetApplication(context, applicationId);
            application.Firm = firm;
            context.Update(application);
            context.SaveChanges();
        }
    }
}
