using MediatR;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways
{
    public class GetAllGatewaysQuery : IRequest<IEnumerable<GatewayDto>>
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string IpV4Address { get; set; }
    }
}
