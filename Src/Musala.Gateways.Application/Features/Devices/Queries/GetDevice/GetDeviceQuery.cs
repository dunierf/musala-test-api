using MediatR;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetDevice
{
    public class GetDeviceQuery : IRequest<DeviceDto>
    {
        public int Id { set; get; }
    }
}
