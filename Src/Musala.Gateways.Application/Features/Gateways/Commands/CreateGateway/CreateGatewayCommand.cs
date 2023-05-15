
using MediatR;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommand : IRequest<GatewayDto>
    {
        public string Name { set; get; }

        public string IpV4Address { set; get; }
    }
}
