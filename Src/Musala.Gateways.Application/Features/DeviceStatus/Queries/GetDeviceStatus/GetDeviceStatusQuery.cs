using MediatR;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetDeviceStatus
{
    public class GetDeviceStatusQuery : IRequest<DeviceStatusDto>
    {
        public int Id { set; get; }
    }
}
