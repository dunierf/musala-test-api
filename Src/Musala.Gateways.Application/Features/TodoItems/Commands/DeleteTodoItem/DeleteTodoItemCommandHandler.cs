﻿using AutoMapper;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Domain.Entities.Sample;
using Musala.Gateways.Persistence.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public DeleteTodoItemCommandHandler(ILogger<DeleteTodoItemCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.TodoItems.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            db.TodoItems.Remove(ent);
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Task.Result;
        }
    }
}
