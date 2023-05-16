using AutoMapper;
using MediatR;
using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.CreateDeviceStatus
{
    public class CreateDeviceStatusCommand : IRequest<DeviceStatusDto>
    {
        public string Name { set; get; }

    }
}
