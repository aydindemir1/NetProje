namespace NetProje.Users.DTOs
{
    public record UserDto(int Id, string UserName, string Password, string Name, string Surname, string Email, DateTime Birthdate, string Address, string PhoneNumber, bool IsAdmin);
}
