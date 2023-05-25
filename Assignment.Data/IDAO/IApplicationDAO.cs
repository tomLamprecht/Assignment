using Assignment.Data.Models.Domains;
using Assignment.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.IDAO
{
    public interface IApplicationDAO
    {
        void AddApplication(AssignmentContext context, Application application);

    }
}
