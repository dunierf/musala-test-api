using MediatR;

namespace Musala.Gateways.Application.Features.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest
    {
        public int Id { set; get; }
    }
}
