

namespace NetProje.Roles
{
    public class RoleRepository:IRoleRepository
    {

       private static List<Role> _roles = 
[
    new Role { Id = 1, Name = "Admin", Description = "Administrator Role" },
    new Role { Id = 2, Name = "User", Description = "Regular User Role" },
    new Role { Id = 3, Name = "Manager", Description = "Manager Role" }
];

        public IReadOnlyList<Role> GetAll()
        {
            return _roles;
        }

        public void Update(Role role)
        {
            var index = _roles.FindIndex(x => x.Id == role.Id);

            _roles[index] = role;
        }

        public void Create(Role role)
        {
            var methodName = nameof(RolesController.GetById); // GetById
            _roles.Add(role);
        }

        public Role? GetById(int id)
        {
            return _roles.Find(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var role = GetById(id);

            _roles.Remove(role!);
        }

    }
}
