using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, DeviceDto>
    {
        private IMapper mapper;
        private AppDbContext db;
        private ILogger logger;

        public CreateDeviceCommandHandler(IMapper mapper, AppDbContext db, ILogger<CreateDeviceCommandHandler> logger)
        {
            this.mapper = mapper;
            this.db = db;
            this.logger = logger;
        }

        public async Task<DeviceDto> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Device()
            {
                UId = request.UId,
                Vendor = request.Vendor,
                StatusId = request.StatusId,
                GatewayId = request.GatewayId,
                CreatedBy = "system",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "system",
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            await db.Devices.AddAsync(entity);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<DeviceDto>(entity);
        }
    }
}
