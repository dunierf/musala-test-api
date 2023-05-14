using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.UpdateDeviceStatus
{
    public class UpdateDeviceStatusCommandValidator : AbstractValidator<UpdateDeviceStatusCommand>
    {
        public UpdateDeviceStatusCommandValidator()
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
        }
    }
}
