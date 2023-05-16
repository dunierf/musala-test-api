using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Domain.Entities.Gateways;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways
{
    public class GatewayDto : IMapFrom<Gateway>
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string SerialNumber { set; get; }
        public string IpV4Address { set; get; }
        public List <DeviceDto> Devices { get; set; }

    }
}
