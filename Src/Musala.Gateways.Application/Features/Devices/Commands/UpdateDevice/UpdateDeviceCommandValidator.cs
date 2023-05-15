using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandValidator : AbstractValidator<UpdateDeviceCommand>
    {
        public UpdateDeviceCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");

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
