using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetDeviceStatus;
using Musala.Gateways.Application.Features.DeviceStatus.Commands.CreateDeviceStatus;
using Musala.Gateways.Application.Features.DeviceStatus.Commands.UpdateDeviceStatus;
using Musala.Gateways.Application.Features.DeviceStatus.Commands.DeleteDeviceStatus;

namespace Musala.Gateways.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceStatusController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DeviceStatusDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllDeviceStatusQuery() { }));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeviceStatusDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDeviceStatusQuery() { Id = id }));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeviceStatusDto))]
        public async Task<IActionResult> Post([FromBody] CreateDeviceStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeviceStatusDto))]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDeviceStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDeviceStatusCommand() { Id = id });
            return NoContent();
        }
    }
}
