using FluentValidation;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetDeviceStatus
{
    public class GetDeviceStatusQueryValidator : AbstractValidator<GetDeviceStatusQuery>
    {
        public GetDeviceStatusQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
