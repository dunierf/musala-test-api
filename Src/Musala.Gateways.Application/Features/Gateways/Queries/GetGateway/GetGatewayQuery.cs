using MediatR;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetGateway
{
    public class GetGatewayQuery : IRequest<GatewayDto>
    {
        public int Id { set; get; }
    }
}
