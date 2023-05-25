using Assignment.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Service
{
    public interface IUserService
    {
        User GetUser(string UserId);

        void UpdateUser(User user);

        void AddUser(User user);

    }
}
