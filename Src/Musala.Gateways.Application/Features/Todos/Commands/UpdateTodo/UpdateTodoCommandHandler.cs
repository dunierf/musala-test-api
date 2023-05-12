﻿using AutoMapper;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos;
using Musala.Gateways.Domain.Entities.Sample;
using Musala.Gateways.Persistence.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public UpdateTodoCommandHandler(ILogger<UpdateTodoCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.Todos.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(Todo), request.Id);

            ent.Name = request.Name;
            ent.ModifiedDate = DateTime.UtcNow;
            ent.LastModifiedBy = "system";
            db.Todos.Update(ent);

            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<TodoDto>(ent);
        }
    }
}
