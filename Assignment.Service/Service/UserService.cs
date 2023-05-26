using Assignment.Data.DAO;
using Assignment.Data.IDAO;
using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using Assignment.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.IService
{
    public class UserService : IUserService
    {
        IUserDAO userDAO;

        public UserService()
        {
            userDAO = new UserDAO();
        }

        public void AddUser(User user)
        {
            using (AssignmentContext context = new AssignmentContext()) {
                userDAO.SaveUser(context, user);
                context.SaveChanges();
            }
        }

        public User GetUser(string UserId)
        {
            using (AssignmentContext context = new AssignmentContext()) {
                return userDAO.GetUser(context, UserId);
            }
        }

        public void UpdateUser(User user)
        {
            using(AssignmentContext context = new AssignmentContext())
            {
                userDAO.UpdateUserDetails(context, user);
                context.SaveChanges();
            }
        }
    }
}
