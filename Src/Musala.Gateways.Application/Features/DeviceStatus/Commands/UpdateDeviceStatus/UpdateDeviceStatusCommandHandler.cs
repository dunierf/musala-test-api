using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.UpdateDeviceStatus
{
    public class UpdateDeviceStatusCommandHandler : IRequestHandler<UpdateDeviceStatusCommand, DeviceStatusDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public UpdateDeviceStatusCommandHandler(ILogger<UpdateDeviceStatusCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<DeviceStatusDto> Handle(UpdateDeviceStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.DeviceStatus.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(DeviceStatus), request.Id);

            entity.Name = request.Name;
            entity.ModifiedDate = DateTime.UtcNow;
            entity.LastModifiedBy = "system";
            db.DeviceStatus.Update(entity);

            await db.SaveChangesAsync(cancellationToken);
            return mapper.Map<DeviceStatusDto>(entity);
        }
    }
}
