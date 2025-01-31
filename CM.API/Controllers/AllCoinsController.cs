using CM.API.RequestModels;
using CM.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllCoinsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AllCoinsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(ImportCoinBlock input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _mediator.Send(new ImportAllBlocksCommand(input.IsTest));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
