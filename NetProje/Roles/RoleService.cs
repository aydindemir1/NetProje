using NetProje.Roles.DTOs;
using NetProje.SharedDTOs;
using System.Collections.Immutable;
using System.Net;

namespace NetProje.Roles
{
    public class RoleService(IRoleRepository roleRepository):IRoleService
    {

        public ResponseModelDto<ImmutableList<RoleDto>> GetAll()
        {
            var roleList = roleRepository.GetAll().Select(role => new RoleDto(
               role.Id,
               role.Name,
               role.Description
            )).ToImmutableList();


            return ResponseModelDto<ImmutableList<RoleDto>>.Success(roleList);
        }

        public ResponseModelDto<RoleDto?> GetByIdRole(int id)
        {
            var hasRole = roleRepository.GetById(id);

            if (hasRole is null)
            {
                return ResponseModelDto<RoleDto?>.Fail("Rol bulunamadı", HttpStatusCode.NotFound);
            }


            var newDto = new RoleDto(
             hasRole.Id,
             hasRole.Name,
             hasRole.Description

            );

            return ResponseModelDto<RoleDto?>.Success(newDto);
        }

        public ResponseModelDto<int> Create(RoleCreateRequestDto request)
        {
            var newRole = new Role
            {
                Id = roleRepository.GetAll().Count + 1,
                Name = request.Name,
                Description = request.Description

            };

            roleRepository.Create(newRole);

            return ResponseModelDto<int>.Success(newRole.Id, HttpStatusCode.Created);
        }

        public ResponseModelDto<NoContent> Update(int roleId, RoleUpdateRequestDto request)
        {
            var hasRole = roleRepository.GetById(roleId);

            if (hasRole is null)
            {
                return ResponseModelDto<NoContent>.Fail("Güncellenmeye çalışılan rol bulunamadı.",
                    HttpStatusCode.NotFound);
            }

            var updatedRole = new Role
            {
                Id = roleId,
                Name = request.Name,
                Description = request.Description

            };

            roleRepository.Update(updatedRole);

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public ResponseModelDto<NoContent> Delete(int id)
        {
            var hasRole = roleRepository.GetById(id);

            if (hasRole is null)
            {
                return ResponseModelDto<NoContent>.Fail("Silinmeye çalışılan rol bulunamadı.",
                    HttpStatusCode.NotFound);
            }


            roleRepository.Delete(id);

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

    }
}
