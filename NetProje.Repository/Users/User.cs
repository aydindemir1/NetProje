using NetProje.Repository.UsersRoles;

namespace NetProje.Repository.Users
{
    public class User:BaseEntity<int>
    { 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
