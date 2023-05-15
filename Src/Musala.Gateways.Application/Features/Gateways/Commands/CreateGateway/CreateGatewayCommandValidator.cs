using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommandValidator : AbstractValidator<CreateGatewayCommand>
    {
        public CreateGatewayCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");

            //
        }
    }
}
