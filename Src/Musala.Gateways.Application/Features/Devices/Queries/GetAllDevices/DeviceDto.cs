using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Domain.Enums;
using System;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices
{
    public class DeviceDto : IMapFrom<Device>
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public string Vendor { set; get; }
        public int StatusId { set; get; }
        public string StatusName { get; set; }

    }
}
