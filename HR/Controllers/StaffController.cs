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

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _staffService.GetAll();

            return Ok(staff);
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
            return Ok(await _staffService.Create(staffCreateModel));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StaffUpdateModel staffUpdateModel)
        {
            return Ok(await _staffService.Update(staffUpdateModel));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _staffService.Delete(id));
        }
    }
}
