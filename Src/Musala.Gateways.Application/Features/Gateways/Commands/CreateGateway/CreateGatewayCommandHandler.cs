using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using Musala.Gateways.Application.Features.Gateways.Queries.GetGateway;
using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommandHandler : IRequestHandler<CreateGatewayCommand, GatewayDto>
    {
        private IMapper mapper;
        private AppDbContext db;
        private ILogger logger;
        private IMediator mediator;

        public CreateGatewayCommandHandler(IMapper mapper, AppDbContext db, ILogger<CreateGatewayCommandHandler> logger, IMediator mediator)
        {
            this.mapper = mapper;
            this.db = db;
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task<GatewayDto> Handle(CreateGatewayCommand request, CancellationToken cancellationToken)
        {
            var entity = new Gateway()
            {
                Name = request.Name,
                IpV4Address = request.IpV4Address,
                SerialNumber = request.SerialNumber,
                CreatedBy = "system",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "system",
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            if (request.Devices.Any())
            {
                entity.Devices = new List<Device>();

                foreach (var device in request.Devices)
                {
                    entity.Devices.Add(new Device()
                    {
                        UId = device.UId,
                        Vendor = device.Vendor,
                        StatusId = device.StatusId
                    });
                }
            }

            await db.Gateways.AddAsync(entity);
            await db.SaveChangesAsync(cancellationToken);

            return await mediator.Send(new GetGatewayQuery() { Id = entity.Id });
        }
    }
}
