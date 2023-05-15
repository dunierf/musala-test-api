
using MediatR;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;

namespace Musala.Gateways.Application.Features.Gateways.Commands.UpdateGateway
{
    public class UpdateGatewayCommand : IRequest<GatewayDto>
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string IpV4Address { set; get; }
    }
}
