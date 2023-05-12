using Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos;
using MediatR;

namespace Musala.Gateways.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Name { set; get; }
    }
}
