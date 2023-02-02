using FluentValidation;
using Hr.Application.Models.EducationModels;
using Hr.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hr.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Education")]

    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IValidator<EducationCreateModel> _validatorCreate;
        private readonly IValidator<EducationUpdateModel> _validatorUpdate;

        public EducationController(IEducationService educationService,
                                  IValidator<EducationCreateModel> validator,
                                  IValidator<EducationUpdateModel> validator1)
        {
            _educationService = educationService;
            _validatorCreate = validator;
            _validatorUpdate = validator1;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _educationService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _educationService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationCreateModel educationCreateModel)
        {
            var result = await _validatorCreate.ValidateAsync(educationCreateModel);

            if (result.IsValid)
            {
                await _educationService.Create(educationCreateModel);

                return Ok("Education успешно добавлен");
            }

            return BadRequest(result.Errors.Select(c => c.ErrorMessage));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] EducationUpdateModel educationUpdateModel)
        {
            var result = await _validatorUpdate.ValidateAsync(educationUpdateModel);

            if (result.IsValid)
            {
                await _educationService.Update(educationUpdateModel);

                return Ok("Education успешно обновлен!");
            }

            return BadRequest(result.Errors.Select(r => r.ErrorMessage));

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _educationService.Delete(id);

            return Ok("Education успешно удален!");
        }
    }
}

