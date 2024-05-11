using NetProje.SharedDTOs;
using NetProje.Users.DTOs;
using System.Collections.Immutable;

namespace NetProje.Users
{
    public interface IUserService
    {
        ResponseModelDto<ImmutableList<UserDto>> GetAll();
        ResponseModelDto<UserDto?> GetByIdUser(int id);
        ResponseModelDto<int> Create(UserCreateRequestDto request);
        ResponseModelDto<NoContent> Update(int userId, UserUpdateRequestDto request);
        ResponseModelDto<NoContent> Delete(int id);
    }
}
