﻿using FluentValidation;

namespace Musala.Gateways.Application.Features.Todos.Queries.GetTodo
{
    public class GetTodoQueryValidator : AbstractValidator<GetTodoQuery>
    {
        public GetTodoQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
