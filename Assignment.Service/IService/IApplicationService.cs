using Assignment.Data.Models.Repository;
using Assignment.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.IService
{
    public interface IApplicationService
    {
        bool AddApplication( ApplicationUserUniversity applicationUserUniversity);

    }
}
