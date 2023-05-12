using MediatR;

namespace Musala.Gateways.Application.Features.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { set; get; }
    }
}
