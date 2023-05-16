using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public DeleteDeviceCommandHandler(ILogger<DeleteDeviceCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.Devices.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(DeviceDto), request.Id);

            db.Devices.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Task.Result;
        }
    }
}
