using Musala.Gateways.Domain.Common;
using System.Collections.Generic;

namespace Musala.Gateways.Domain.Entities.Devices
{
    public class DeviceStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}