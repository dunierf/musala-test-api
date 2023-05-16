using FluentValidation;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommandValidator : AbstractValidator<CreateGatewayCommand>
    {
        public CreateGatewayCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(c => c.SerialNumber)
                .NotEmpty()
                .WithMessage("Serial number is required");

            RuleFor(c => c.IpV4Address)
                .NotEmpty()
                .WithMessage("Ip v4 address is required");

            RuleFor(c => c.IpV4Address)
                .Matches("^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
                .WithMessage("Invalid Ip v4 address");
        }
    }
}
