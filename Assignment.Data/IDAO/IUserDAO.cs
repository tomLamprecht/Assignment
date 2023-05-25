using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.IDAO
{
    public interface IUserDAO
    {
        User GetUser(AssignmentContext context, String id);

        void AddApplicationToUser(AssignmentContext context, Application application, string userId);

        void RemoveApplicationFromUser(AssignmentContext context, Application application, string userId);

        User GetUser(AssignmentContext context, Application application);

        void UpdateUserDetails(AssignmentContext context, User user);

        void SaveUser(AssignmentContext context, User user);
    }
}
