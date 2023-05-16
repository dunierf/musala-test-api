using MediatR;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices
{
    public class GetAllDevicesQuery : IRequest<IEnumerable<DeviceDto>>
    {
        public int Id { set; get; }
    }
}
