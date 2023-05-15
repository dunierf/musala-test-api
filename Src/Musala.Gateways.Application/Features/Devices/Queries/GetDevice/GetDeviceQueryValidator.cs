using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetDevice
{
    public class GetDeviceQueryValidator : AbstractValidator<GetDeviceQuery>
    {
        public GetDeviceQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
