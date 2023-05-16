using FluentValidation;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetDevice
{
    public class GetDeviceQueryValidator : AbstractValidator<GetDeviceQuery>
    {
        public GetDeviceQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required, integer number greater than zero");
        }
    }
}
