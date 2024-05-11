namespace NetProje.Users.DTOs
{
    public record UserUpdateRequestDto(string Username, string Password, string Surname, string Name, string Email, DateTime Birthdate, string Address, string PhoneNumber);
}
