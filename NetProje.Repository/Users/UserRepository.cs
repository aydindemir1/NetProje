using NetProje.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }


        public async Task UpdateUserName(string name, int id)
        {
            var User = await GetById(id);
            User!.Name = name;
            await Update(User);
        }
    }
}
