namespace NetProje.Users
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users =
        [
              new User
    {
        Id = 1,
        UserName = "john_doe",
        Password = "password123",
        Name = "John",
        Surname = "Doe",
        Email = "john@example.com",
        Birthdate = new DateTime(1990, 5, 15),
        Address = "123 Main Street",
        PhoneNumber = "555-1234",
        IsAdmin = false
    },
    new User
    {
        Id = 2,
        UserName = "jane_smith",
        Password = "letmein",
        Name = "Jane",
        Surname = "Smith",
        Email = "jane@example.com",
        Birthdate = new DateTime(1985, 10, 20),
        Address = "456 Elm Street",
        PhoneNumber = "555-5678",
        IsAdmin = true
    },
    new User
    {
        Id = 3,
        UserName = "bob_johnson",
        Password = "password456",
        Name = "Bob",
        Surname = "Johnson",
        Email = "bob@example.com",
        Birthdate = new DateTime(1982, 8, 8),
        Address = "789 Oak Street",
        PhoneNumber = "555-9012",
        IsAdmin = false
    }
];

        public IReadOnlyList<User> GetAll()
        {
            return _users;
        }

        public void Update(User user)
        {
            var index = _users.FindIndex(x => x.Id == user.Id);

            _users[index] = user;
        }

        public void Create(User user)
        {
            var methodName = nameof(UsersController.GetById); // GetById
            _users.Add(user);
        }

        public User? GetById(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var user = GetById(id);

            _users.Remove(user!);
        }

    }
}
