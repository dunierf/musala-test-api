using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.DeleteDeviceStatus
{
    public class DeleteDeviceStatusCommandValidator : AbstractValidator<DeleteDeviceStatusCommand>
    {
        public DeleteDeviceStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
