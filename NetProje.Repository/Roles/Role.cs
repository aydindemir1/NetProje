using NetProje.Repository.UsersRoles;

namespace NetProje.Repository.Roles
{
    public class Role:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }

}
