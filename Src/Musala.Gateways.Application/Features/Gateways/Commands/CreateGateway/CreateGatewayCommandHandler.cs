using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommandHandler : IRequestHandler<CreateGatewayCommand, GatewayDto>
    {
        private IMapper mapper;
        private AppDbContext db;
        private ILogger logger;

        public CreateGatewayCommandHandler(IMapper mapper, AppDbContext db, ILogger<CreateGatewayCommandHandler> logger)
        {
            this.mapper = mapper;
            this.db = db;
            this.logger = logger;
        }

        public async Task<GatewayDto> Handle(CreateGatewayCommand request, CancellationToken cancellationToken)
        {
            var entity = new Gateway()
            {
                Name = request.Name,
                IpV4Address = request.IpV4Address,
                CreatedBy = "system",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "system",
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            await db.Gateways.AddAsync(entity);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<GatewayDto>(entity);
        }
    }
}
