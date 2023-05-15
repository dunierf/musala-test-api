using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Commands.DeleteGateway
{
    public class DeleteGatewayCommandValidator : AbstractValidator<DeleteGatewayCommand>
    {
        public DeleteGatewayCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
