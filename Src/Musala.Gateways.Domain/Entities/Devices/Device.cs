using Musala.Gateways.Domain.Common;
using Musala.Gateways.Domain.Entities.Gateways;

namespace Musala.Gateways.Domain.Entities.Devices
{
    public class Device : BaseEntity
    {
        public int UId { get; set; }

        public string Vendor { get; set; }

        public int StatusId { get; set; }

        public DeviceStatus Status { get; set; }

        public int GatewayId { get; set; }

        public Gateway Gateway { get; set; }

    }
}
