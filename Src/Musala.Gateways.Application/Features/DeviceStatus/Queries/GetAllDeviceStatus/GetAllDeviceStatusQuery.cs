using MediatR;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus
{
    public class GetAllDeviceStatusQuery : IRequest<IEnumerable<DeviceStatusDto>>
    {
        public int Id { set; get; }

        public string Name { set; get; }
    }
}
