using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandValidator : AbstractValidator<UpdateDeviceCommand>
    {
        public UpdateDeviceCommandValidator()
        {
            RuleFor(c => c.UId)
                .NotEmpty()
                .NotNull()
                .WithMessage("UId is required");

            RuleFor(c => c.Vendor)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");

            RuleFor(c => c.StatusId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("SatusId is required");

            RuleFor(c => c.GatewayId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("GatewayId is required");
        }
    }
}
