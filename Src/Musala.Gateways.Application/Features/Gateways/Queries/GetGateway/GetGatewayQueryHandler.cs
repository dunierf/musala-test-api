﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using Musala.Gateways.Persistence.Contexts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetGateway
{
    public class GetGatewayQueryHandler : IRequestHandler<GetGatewayQuery, GatewayDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public GetGatewayQueryHandler(ILogger<GetGatewayQueryHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<GatewayDto> Handle(GetGatewayQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Gateways
                    .Include(c => c.Devices)
                    .ThenInclude( c => c.Status )
                    .Where(c => c.Id == request.Id)
                    .FirstOrDefaultAsync();

            if (entity == null)
                throw new NotFoundException(nameof(Gateways), request.Id);

            return mapper.Map<GatewayDto>(entity);
        }
    }
}
