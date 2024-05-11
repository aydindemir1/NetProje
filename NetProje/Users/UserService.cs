using NetProje.SharedDTOs;
using NetProje.Users.DTOs;
using System.Collections.Immutable;
using System.Net;

namespace NetProje.Users
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
       

        public ResponseModelDto<ImmutableList<UserDto>> GetAll()
        {
            var userList = userRepository.GetAll().Select(user => new UserDto(
                user.Id,
                user.UserName,
                user.Password,
                user.Name,
                user.Surname,
                user.Email,
                user.Birthdate,
                user.Address,
                user.PhoneNumber,
                user.IsAdmin
            )).ToImmutableList();


            return ResponseModelDto<ImmutableList<UserDto>>.Success(userList);
        }

        public ResponseModelDto<UserDto?> GetByIdUser(int id)
        {
            var hasUser = userRepository.GetById(id);

            if (hasUser is null)
            {
                return ResponseModelDto<UserDto?>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }


            var newDto = new UserDto(
               hasUser.Id,
               hasUser.UserName,
               hasUser.Password,
               hasUser.Name,
               hasUser.Surname,
               hasUser.Email,
               hasUser.Birthdate,
               hasUser.Address,
               hasUser.PhoneNumber,
               hasUser.IsAdmin

            );

            return ResponseModelDto<UserDto?>.Success(newDto);
        }

        public ResponseModelDto<int> Create(UserCreateRequestDto request)
        {
            var newUser = new User
            {
                Id = userRepository.GetAll().Count + 1,
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Birthdate = request.Birthdate,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                IsAdmin = false
            };

            userRepository.Create(newUser);

            return ResponseModelDto<int>.Success(newUser.Id, HttpStatusCode.Created);
        }

        public ResponseModelDto<NoContent> Update(int userId, UserUpdateRequestDto request)
        {
            var hasUser = userRepository.GetById(userId);

            if (hasUser is null)
            {
                return ResponseModelDto<NoContent>.Fail("Güncellenmeye çalışılan kullanıcı bulunamadı.",
                    HttpStatusCode.NotFound);
            }

            var updatedUser = new User
            {
                Id = userId,
                UserName = request.Username,
                Password = request.Password,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Birthdate = request.Birthdate,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                IsAdmin = false

            };

            userRepository.Update(updatedUser);

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


        public ResponseModelDto<NoContent> Delete(int id)
        {
            var hasUser = userRepository.GetById(id);

            if (hasUser is null)
            {
                return ResponseModelDto<NoContent>.Fail("Silinmeye çalışılan kullanıcı bulunamadı.",
                    HttpStatusCode.NotFound);
            }


            userRepository.Delete(id);

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


    }
}
