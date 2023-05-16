using MediatR;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.UpdateDeviceStatus
{
    public class UpdateDeviceStatusCommand : IRequest<DeviceStatusDto>
    {
        public int Id { get; set; }
        public string Name { set; get; }
    }
}
