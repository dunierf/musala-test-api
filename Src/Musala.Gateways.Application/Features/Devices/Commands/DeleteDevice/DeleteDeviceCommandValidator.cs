using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandValidator : AbstractValidator<DeleteDeviceCommand>
    {
        public DeleteDeviceCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
