using MediatR;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.DeleteDeviceStatus
{
    public class DeleteDeviceStatusCommand : IRequest
    {
        public int Id { set; get; }
    }
}
