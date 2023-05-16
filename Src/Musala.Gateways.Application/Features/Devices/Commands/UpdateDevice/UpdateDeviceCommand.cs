using MediatR;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;

namespace Musala.Gateways.Application.Features.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommand : IRequest<DeviceDto>
    {
        public int Id { get; set; }
        public int UId { set; get; }
        public string Vendor { set; get; }
        public int StatusId { set; get; }
        public int GatewayId { set; get; }
    }
}
