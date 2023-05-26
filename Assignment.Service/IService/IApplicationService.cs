using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using Assignment.Service.Models;
using Microsoft.AspNetCore.Identity;
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

        void DeleteApplication(int applicationId);

        Application GetApplication(int applicationId);

        void SetFirm(int applicationId, bool firm);

    }
}
