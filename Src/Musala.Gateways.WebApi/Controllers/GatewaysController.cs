using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway;
using Musala.Gateways.Application.Features.Gateways.Commands.DeleteGateway;
using Musala.Gateways.Application.Features.Gateways.Commands.UpdateGateway;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using Musala.Gateways.Application.Features.Gateways.Queries.GetGateway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musala.Gateways.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GatewayDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllGatewaysQuery() { }));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GatewayDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetGatewayQuery() { }));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GatewayDto))]
        public async Task<IActionResult> Post([FromBody] CreateGatewayCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GatewayDto))]
        public async Task<IActionResult>  Put(int id, [FromBody] UpdateGatewayCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGatewayCommand() { Id = id });
            return NoContent();
        }
    }
}
