using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Commands.UpdateGateway
{
    public class UpdateGatewayCommandValidator : AbstractValidator<UpdateGatewayCommand>
    {
        public UpdateGatewayCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");

            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");

            //
        }
    }
}
