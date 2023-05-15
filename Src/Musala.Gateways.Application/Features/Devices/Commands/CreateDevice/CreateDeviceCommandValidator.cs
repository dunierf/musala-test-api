using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommandValidator : AbstractValidator<CreateDeviceCommand>
    {
        public CreateDeviceCommandValidator()
        {
            RuleFor(c => c.UId)
                .NotEmpty()
                .WithMessage("UId is required");

            RuleFor(c => c.Vendor)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(c => c.StatusId)
                .NotEmpty()
                .WithMessage("Status Id is required");

            RuleFor(c => c.GatewayId)
                .NotEmpty()
                .WithMessage("GatewayId is required");
        }
    }
}
