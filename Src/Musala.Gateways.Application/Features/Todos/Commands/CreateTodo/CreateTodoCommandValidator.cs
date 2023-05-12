﻿using FluentValidation;

namespace Musala.Gateways.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");

        }
    }
}
