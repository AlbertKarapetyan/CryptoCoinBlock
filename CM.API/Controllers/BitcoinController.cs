using CM.API.RequestModels;
using CM.Application.Commands;
using CM.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitcoinController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BitcoinController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(ImportCoinBlock input)
        {
            try
            {
                var result = await _mediator.Send(new ImportBitcoinBlockCommand(input.IsTest));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory([FromQuery] bool isTest, [FromQuery] short limit)
        {
            try
            {
                var result = await _mediator.Send(new GetBitcoinBlocksQuery(isTest, limit));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
