﻿namespace NetProje.Users.DTOs
{
    public record UserCreateRequestDto(string UserName, string Password, string Name, string Surname, string Email, DateTime Birthdate, string Address, string PhoneNumber);
}
