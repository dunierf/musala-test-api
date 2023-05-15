using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.UpdateDeviceStatus
{
    public class UpdateDeviceStatusCommandValidator : AbstractValidator<UpdateDeviceStatusCommand>
    {
        public UpdateDeviceStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}
