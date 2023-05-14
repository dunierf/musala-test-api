using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Todos.Commands.DeleteTodo;
using Musala.Gateways.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.DeleteDeviceStatus
{
    public class DeleteDeviceStatusCommandHandler : IRequestHandler<DeleteDeviceStatusCommand>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public DeleteDeviceStatusCommandHandler(ILogger<DeleteTodoCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeviceStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.DeviceStatus.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(DeviceStatus), request.Id);

            db.DeviceStatus.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Task.Result;
        }
    }
}
