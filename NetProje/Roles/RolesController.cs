using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.Controllers;
using NetProje.Roles.DTOs;


namespace NetProje.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{roleId}")]
        public IActionResult GetById(int roleId)
        {
            return CreateActionResult(_roleService.GetByIdRole(roleId));
        }

        [HttpPost]
        public IActionResult Create(RoleCreateRequestDto request)
        {
            var result = _roleService.Create(request);
            return CreateActionResult(result, nameof(GetById), new { roleId = result.Data });
        }

        [HttpPut("{roleId}")]
        public IActionResult Update(int roleId, RoleUpdateRequestDto request)
        {
            return CreateActionResult(_roleService.Update(roleId, request));
        }

        [HttpDelete("{roleId}")]
        public IActionResult Delete(int roleId)
        {
            return CreateActionResult(_roleService.Delete(roleId));
        }

    }
}
