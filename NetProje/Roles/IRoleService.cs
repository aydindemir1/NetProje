using NetProje.Roles.DTOs;
using NetProje.SharedDTOs;
using System.Collections.Immutable;

namespace NetProje.Roles
{
    public interface IRoleService
    {
        ResponseModelDto<ImmutableList<RoleDto>> GetAll();
        ResponseModelDto<RoleDto?> GetByIdRole(int id);
        ResponseModelDto<int> Create(RoleCreateRequestDto request);
        ResponseModelDto<NoContent> Update(int roleId, RoleUpdateRequestDto request);
        ResponseModelDto<NoContent> Delete(int id);


    }
}
