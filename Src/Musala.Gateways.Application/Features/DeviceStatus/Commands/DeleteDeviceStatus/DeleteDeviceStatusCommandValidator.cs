using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.DeleteDeviceStatus
{
    public class DeleteDeviceStatusCommandValidator : AbstractValidator<DeleteDeviceStatusCommand>
    {
        public DeleteDeviceStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
