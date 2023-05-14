using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Domain.Entities.Devices;
using System;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus
{
    public class DeviceStatusDto : IMapFrom<Domain.Entities.Devices.DeviceStatus>
    {
        public int Id { get; set; }
        public string Name { set; get; }

    }
}
