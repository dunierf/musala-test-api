
using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetGateway
{
    public class GetGatewayQueryValidator : AbstractValidator<GetGatewayQuery>
    {
        public GetGatewayQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
