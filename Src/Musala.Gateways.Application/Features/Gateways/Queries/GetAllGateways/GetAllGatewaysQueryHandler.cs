using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos;
using Musala.Gateways.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways
{
    public class GetAllGatewaysQueryHandler : IRequestHandler<GetAllGatewaysQuery, IEnumerable<GatewayDto>>
    {
        private AppDbContext db;
        private ILogger logger;
        private IMapper mapper;

        public GetAllGatewaysQueryHandler(AppDbContext db, ILogger<GetAllTodosQueryHandler> logger, IMapper mapper)
        {
            this.db = db;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GatewayDto>> Handle(GetAllGatewaysQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<GatewayDto>(db.Gateways.AsNoTracking());
        }
    }
}
