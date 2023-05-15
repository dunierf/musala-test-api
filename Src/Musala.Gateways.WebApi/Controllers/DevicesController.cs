using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musala.Gateways.Application.Features.Devices.Commands.CreateDevice;
using Musala.Gateways.Application.Features.Devices.Commands.DeleteDevice;
using Musala.Gateways.Application.Features.Devices.Commands.UpdateDevice;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Application.Features.Devices.Queries.GetDevice;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musala.Gateways.WebApi.Controllers
{
    [Route("api/gateways/{gatewayId}/[controller]")]
    [ApiController]
    public class DevicesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DeviceDto>))]
        public async Task<IActionResult> Get([FromRoute] int gatewayId)
        {
            return Ok(await Mediator.Send(new GetAllDevicesQuery() { Id = gatewayId }));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeviceDto))]
        public async Task<IActionResult> Get([FromRoute] int gatewayId, [FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDeviceQuery() { Id = id }));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeviceDto))]
        public async Task<IActionResult> Post([FromRoute] int gatewayId, [FromBody] CreateDeviceCommand command)
        {
            command.GatewayId = gatewayId;
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeviceDto))]
        public async Task<IActionResult> Put([FromRoute] int gatewayId, [FromRoute] int id, [FromBody] UpdateDeviceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDeviceCommand() { Id = id });
            return NoContent();
        }
    }
}
