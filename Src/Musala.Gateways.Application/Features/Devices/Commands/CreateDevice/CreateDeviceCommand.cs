using MediatR;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;

namespace Musala.Gateways.Application.Features.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<DeviceDto>
    {
        public int UId { set; get; }
        public string Vendor { set; get; }
        public int StatusId { set; get; }
        public int GatewayId { set; get; }
    }
}
