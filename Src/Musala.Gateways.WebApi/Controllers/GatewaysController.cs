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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Musala.Gateways.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : BaseController
    {
        // GET: api/<GatewaysController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GatewayDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllGatewaysQuery() { }));
        }

        // GET api/<GatewaysController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GatewayDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetGatewayQuery() { }));
        }

        // POST api/<GatewaysController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GatewayDto))]
        public async Task<IActionResult> Post([FromBody] CreateGatewayCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<GatewaysController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GatewayDto))]
        public async Task<IActionResult>  Put(int id, [FromBody] UpdateGatewayCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<GatewaysController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGatewayCommand() { Id = id });
            return NoContent();
        }
    }
}
