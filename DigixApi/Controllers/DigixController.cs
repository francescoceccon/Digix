using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigixApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DigixController : ControllerBase
    {
        [HttpPost("insertFamily")]
        public IActionResult InsertFamily([FromBody] Family family,[FromServices] ICriterionUseCase criterionUseCase)
        {
            criterionUseCase.InsertFamilyAsync(family);

            return Ok("Family Inserted Succesfuly");
        }


        [HttpGet("applyStrategy")]
        public async Task<IActionResult> ApplyCriterionStrategyAsync([FromServices] ICriterionUseCase criterionUseCase)
        {
            var result = await criterionUseCase.ApplyCriterionStrategyAsync();

            return Ok(result);
        }

        [HttpPost("applyChainOfResponsability")]
        public async Task<IActionResult> AppyCriterionChainOfResponsabilityAsync([FromBody] Family family, [FromServices] ICriterionUseCase criterionUseCase)
        {
            var result = await criterionUseCase.ApplyCriterionChainAsync();

            return Ok(result);
        }
    }
}
