using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.CreateDeviceStatus
{
    public class CreateDeviceStatusCommandValidator : AbstractValidator<CreateDeviceStatusCommand>
    {
        public CreateDeviceStatusCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");
        }
    }
}
