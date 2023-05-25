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
    public class UserDAO : IUserDAO
    {
        public User GetUser(AssignmentContext context, string id) {
            return context.Users.Find(id) ?? throw new Exception("No user Found for id " + id);
        }
    }
}
