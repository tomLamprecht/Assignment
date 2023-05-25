using Assignment.Data.DAO;
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
        ApplicationDAO applicationDAO;
        UserDAO userDAO;
        UniversityDAO universityDAO;

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
    }
}
