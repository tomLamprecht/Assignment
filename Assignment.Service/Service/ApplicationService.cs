using Assignment.Data.DAO;
using Assignment.Data.IDAO;
using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using Assignment.Service.IService;
using Assignment.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Service
{
    public class ApplicationService : IApplicationService
    {
        IApplicationDAO applicationDAO;
        IUserDAO userDAO;
        IUniversityDAO universityDAO;

        public ApplicationService()
        {
            applicationDAO = new ApplicationDAO();
            userDAO = new UserDAO();
            universityDAO = new UniversityDAO();
        }

        public bool AddApplication(ApplicationUserUniversity data)
        {
            try
            {
                #region(Prepare Application object)
                Application application = new Application()
                {
                    Course = data.Course,
                    Statement = data.Statement,
                    TeacherContact = data.TeacherContact,
                    Firm = false,
                    Offer = "",
                    TeacherReference =""
                };
                #endregion
                #region(Unit of work - Do the work)
                using(AssignmentContext context = new AssignmentContext())
                {
                    applicationDAO.AddApplication(context, application);
                    University uni = universityDAO.GetUniversity(context, data.UniversityId);
                    universityDAO.AddApplicationToCollection(context, application, uni);
                    userDAO.AddApplicationToUser(context, application, data.UserId);
                    context.SaveChanges();
                }
                #endregion
                return true; 

            }
            catch
            {
                return false; 
            }
        }

        public void DeleteApplication(int applicationId)
        {
            using (AssignmentContext context = new AssignmentContext()) {
                Application application = applicationDAO.GetApplication(context, applicationId);
                User user = userDAO.GetUser(context, application);
                userDAO.RemoveApplicationFromUser(context, application, user.UserId);
                University university = universityDAO.GetUniversity(context, application);
                universityDAO.RemoveApplicationFromCollection(context, application, university);
                applicationDAO.DeleteApplication(context, application);
                context.SaveChanges();
            }
        }

        public Application GetApplication(int applicationId)
        {
            using (AssignmentContext context = new AssignmentContext())
            {
                return applicationDAO.GetApplication(context, applicationId);
            }
        }

        public void SetFirm(int applicationId, bool firm)
        {
            using (AssignmentContext context = new AssignmentContext())
            {
                applicationDAO.SetFirm(context, applicationId, firm);
            }
        }
    }
}
