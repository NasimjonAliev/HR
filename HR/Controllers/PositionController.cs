using FluentValidation;
using Hr.Application.Models.PositionModels;
using Hr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hr.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/staff")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IValidator<PositionCreateModel> _validatorCreate;
        private readonly IValidator<PositionUpdateModel> _validatorUpdate;

        public PositionController(IPositionService positionService,
                                  IValidator<PositionCreateModel> validator,
                                  IValidator<PositionUpdateModel> validator1)
        {
            _positionService = positionService;
            _validatorCreate = validator;
            _validatorUpdate = validator1;
        }   

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _positionService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _positionService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PositionCreateModel positionCreateModel)
        {
            var result = await _validatorCreate.ValidateAsync(positionCreateModel);

            if (result.IsValid)
            {
                await _positionService.Create(positionCreateModel);

                return Ok("Позиция успешно добавлен");
            }

            return BadRequest(result.Errors.Select(c => c.ErrorMessage));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PositionUpdateModel positionUpdateModel)
        {
            var result = await _validatorUpdate.ValidateAsync(positionUpdateModel);

            if (result.IsValid)
            {
                await _positionService.Update(positionUpdateModel);

                return Ok("Позиция успешно обновлен!");
            }

            return BadRequest(result.Errors.Select(r => r.ErrorMessage));

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _positionService.Delete(id);

            return Ok("Позиция успешно удален!");
        }
    }
}
