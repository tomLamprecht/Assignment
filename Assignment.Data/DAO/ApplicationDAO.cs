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
    }
}
