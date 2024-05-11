using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.Controllers;
using NetProje.Users.DTOs;

namespace NetProje.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            return CreateActionResult(_userService.GetByIdUser(userId));
        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestDto request)
        {
            var result = _userService.Create(request);
            return CreateActionResult(result, nameof(GetById), new { userId = result.Data });
        }

        [HttpPut("{userId}")]
        public IActionResult Update(int userId, UserUpdateRequestDto request)
        {
            return CreateActionResult(_userService.Update(userId, request));
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            return CreateActionResult(_userService.Delete(userId));
        }

    }
}

