using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Domain.Entities.Devices;
using System;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices
{
    public class DeviceDto : IMapFrom<Device>
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public string Vendor { set; get; }
        public int GatewayId { set; get; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsActive { set; get; }

    }
}
