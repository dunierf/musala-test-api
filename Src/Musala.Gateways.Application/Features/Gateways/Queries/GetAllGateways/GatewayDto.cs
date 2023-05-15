using Musala.Gateways.Application.Common.Interfaces.Mappings;
using Musala.Gateways.Domain.Entities.Gateways;
using System;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways
{
    public class GatewayDto : IMapFrom<Gateway>
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string SerialNumber { set; get; }
        public string IpV4Address { set; get; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsActive { set; get; }
    }
}
