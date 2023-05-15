using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandValidator : AbstractValidator<DeleteDeviceCommand>
    {
        public DeleteDeviceCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
