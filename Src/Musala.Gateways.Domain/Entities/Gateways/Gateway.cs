using Musala.Gateways.Domain.Common;
using Musala.Gateways.Domain.Entities.Devices;
using System.Collections.Generic;

namespace Musala.Gateways.Domain.Entities.Gateways
{
    public class Gateway : BaseEntity
    {
        public string SerialNumber { get; set; }

        public string Name { get; set; }

        public string IpV4Address { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
