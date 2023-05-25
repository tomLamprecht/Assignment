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
    public class UserDAO : IUserDAO
    {
        public void AddApplicationToUser(AssignmentContext context, Application application, string userId)
        {
            User user = GetUser(context, userId);
            if (user.Applications == null)
            {
                user.Applications = new List<Application>();
            }
            user.Applications.Add(application);
            context.SaveChanges();
            
        }

 

        public User GetUser(AssignmentContext context, string id) {
            context.Users.Include(user => user.Applications).Include(user => user.Universities).ToList();
            return context.Users.Find(id) ?? throw new Exception("No user Found for id " + id);
        }

        public User GetUser(AssignmentContext context, Application application)
        {
            IList<User> users = context.Users.Include(user => user.Applications).ToList();
            foreach (var user in users)
            {
                if (user.Applications.Any(app => app.ApplicationId == application.ApplicationId))
                {
                    return user;
                }
            }
            return null;
        }

        public void RemoveApplicationFromUser(AssignmentContext context, Application application, string userId)
        {
            User user = GetUser(context, userId);
            if (user.Applications != null)
            {
                user.Applications.Remove(application);
                context.SaveChanges();
            }
        }

        public void SaveUser(AssignmentContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUserDetails(AssignmentContext context, User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
