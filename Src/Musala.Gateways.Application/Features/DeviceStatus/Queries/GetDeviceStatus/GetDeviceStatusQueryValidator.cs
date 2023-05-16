using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetDeviceStatus
{
    public class GetDeviceStatusQueryValidator : AbstractValidator<GetDeviceStatusQuery>
    {
        public GetDeviceStatusQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
