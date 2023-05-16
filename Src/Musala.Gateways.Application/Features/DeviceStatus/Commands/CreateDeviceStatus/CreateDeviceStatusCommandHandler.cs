using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;

namespace Musala.Gateways.Application.Features.DeviceStatus.Commands.CreateDeviceStatus
{
    public class CreateDeviceStatusCommandHandler : IRequestHandler<CreateDeviceStatusCommand, DeviceStatusDto>
    {
        private IMapper mapper;
        private AppDbContext db;
        private ILogger logger;

        public CreateDeviceStatusCommandHandler(IMapper mapper, AppDbContext db, ILogger<CreateDeviceStatusCommandHandler> logger)
        {
            this.mapper = mapper;
            this.db = db;
            this.logger = logger;
        }

        public async Task<DeviceStatusDto> Handle(CreateDeviceStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new Musala.Gateways.Domain.Entities.Devices.DeviceStatus()
            {
                Name = request.Name,
                CreatedBy = "system",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "system",
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            await db.DeviceStatus.AddAsync(entity);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<DeviceStatusDto>(entity);
        }
    }
}
