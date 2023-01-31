using FluentValidation;
using Hr.Application.Models.StaffModels;
using Hr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hr.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/staff")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IValidator<StaffCreateModel> _validatorCreate;
        private readonly IValidator<StaffUpdateModel> _validatorUpdate;

        public StaffController(IStaffService staffService, 
            IValidator<StaffCreateModel> validatorCreate,
            IValidator<StaffUpdateModel> validatorUpdate)
        {
            _staffService = staffService;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffs = await _staffService.GetAll();

            return Ok(staffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var staff = await _staffService.GetById(id);

            return Ok(staff);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StaffCreateModel staffCreateModel)
        {
            var result = await _validatorCreate.ValidateAsync(staffCreateModel);

            if (result.IsValid)
            {
                await _staffService.Create(staffCreateModel);

                return Ok("Сотрудник успешно добавлен");
            }

            return BadRequest(result.Errors.Select(c => c.ErrorMessage));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StaffUpdateModel staffUpdateModel)
        {
            var result = await _validatorUpdate.ValidateAsync(staffUpdateModel);

            if (result.IsValid)
            {
                await _staffService.Update(staffUpdateModel);

                return Ok("Сотрудник успешно обновлен!");
            }

            return BadRequest(result.Errors.Select(r => r.ErrorMessage));
            
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _staffService.Delete(id);

            return Ok("Сотрудник успешно удален!");
        }
    }
}
