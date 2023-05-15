using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, DeviceDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public UpdateDeviceCommandHandler(ILogger<UpdateDeviceCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<DeviceDto> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.Devices.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Devices), request.Id);

            entity.UId = request.UId;
            entity.Vendor = request.Vendor;
            entity.StatusId = request.StatusId;
            entity.GatewayId = request.GatewayId;
            entity.LastModifiedBy = "system";
            entity.ModifiedDate = DateTime.UtcNow;

            db.Devices.Update(entity);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<DeviceDto>(entity);
        }
    }
}
