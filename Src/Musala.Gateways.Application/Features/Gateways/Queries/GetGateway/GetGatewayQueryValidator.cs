
using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetGateway
{
    public class GetGatewayQueryValidator : AbstractValidator<GetGatewayQuery>
    {
        public GetGatewayQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
