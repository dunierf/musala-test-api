using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Persistence.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Commands.UpdateGateway
{
    public class UpdateGatewayCommandHandler : IRequestHandler<UpdateGatewayCommand, GatewayDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public UpdateGatewayCommandHandler(ILogger<UpdateGatewayCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<GatewayDto> Handle(UpdateGatewayCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.Gateways.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Gateway), request.Id);

            entity.Name = request.Name;
            entity.IpV4Address = request.IpV4Address;
            entity.ModifiedDate = DateTime.UtcNow;
            entity.LastModifiedBy = "system";

            db.Gateways.Update(entity);

            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<GatewayDto>(entity);
        }
    }
}
