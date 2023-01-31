using FluentValidation;
using Hr.Application.Models.UserModels;
using Hr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hr.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserCreateModel> _validatorCreate;
        private readonly IValidator<UserUpdateModel> _validatorUpdate;

        public UserController(IUserService userService, 
            IValidator<UserUpdateModel> validator, 
            IValidator<UserCreateModel> validator1)
        {
            _userService = userService;
            _validatorUpdate = validator;
            _validatorCreate = validator1;
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

        [HttpGet("update/{id}")]
        public async Task<IActionResult> GetByIdUpdate([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdUpdate(id);

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserCreateModel userCreateModel)
        {
            var result = await _validatorCreate.ValidateAsync(userCreateModel);

            if (result.IsValid)
            {
                await _userService.Create(userCreateModel);

                return Ok("Пользователь успешно добавлен");
            }
            else
                return BadRequest(result.Errors.Select(c => c.ErrorMessage));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel userUpdateModel)
        {
            var result = await _validatorUpdate.ValidateAsync(userUpdateModel);

            if (result.IsValid)
            {
                await _userService.Update(userUpdateModel);

                return Ok("Пользователь успешно обновлен");
            }

            return BadRequest(result.Errors.Select(g => g.ErrorMessage));           
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userService.Delete(id);

            return Ok("Пользователь успешно удалено");
        }
    }
}
