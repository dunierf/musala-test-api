using Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos;
using MediatR;

namespace Musala.Gateways.Application.Features.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public int Id { set; get; }
    }
}
