using MediatR;

namespace Musala.Gateways.Application.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest
    {
        public int Id { set; get; }
    }
}
