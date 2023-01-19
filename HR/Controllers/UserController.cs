using Hr.Application.Models.UserModels;
using Hr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hr.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);     
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserCreateModel userCreateModel)
        {
            return Ok(await _userService.Create(userCreateModel));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel userUpdateModel)
        {
            return Ok(await _userService.Update(userUpdateModel));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _userService.Delete(id));
        }
    }
}
