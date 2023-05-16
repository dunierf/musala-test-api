using FluentValidation;
using Musala.Gateways.Application.Features.TodoItems.Queries.GetAllTodoItems;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices
{
    public class GetAllDevicesQueryValidator : AbstractValidator<GetAllTodoItemsQuery>
    {
        public GetAllDevicesQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
