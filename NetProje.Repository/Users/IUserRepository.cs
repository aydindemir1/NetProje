using NetProje.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateUserName(string name, int id);
    }
}
