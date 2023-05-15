using MediatR;

namespace Musala.Gateways.Application.Features.Gateways.Commands.DeleteGateway
{
    public class DeleteGatewayCommand : IRequest
    {
        public int Id { set; get; }
    }
}
