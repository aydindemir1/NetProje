using NetProje.Repository.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Roles
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task UpdateRoleName(string name, int id);
    }
}
