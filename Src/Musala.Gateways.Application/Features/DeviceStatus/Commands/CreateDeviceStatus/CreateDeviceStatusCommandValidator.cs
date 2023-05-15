using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.CreateDeviceStatus
{
    public class CreateDeviceStatusCommandValidator : AbstractValidator<CreateDeviceStatusCommand>
    {
        public CreateDeviceStatusCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}
