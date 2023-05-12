﻿using MediatR;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<IEnumerable<TodoDto>>
    {
        public int Id { set; get; }

        public string Name { set; get; }
    }
}
