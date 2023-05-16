using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Commands.DeleteGateway
{
    public class DeleteGatewayCommandValidator : AbstractValidator<DeleteGatewayCommand>
    {
        public DeleteGatewayCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
