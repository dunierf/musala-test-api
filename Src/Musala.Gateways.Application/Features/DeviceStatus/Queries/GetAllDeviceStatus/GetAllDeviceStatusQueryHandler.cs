using AutoMapper;
using Musala.Gateways.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;
using Musala.Gateways.Application.Features.Todos.Queries.GetAllTodos;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus
{
    public class GetAllDeviceStatusQueryHandler : IRequestHandler<GetAllDeviceStatusQuery, IEnumerable<DeviceStatusDto>>
    {
        private AppDbContext db;
        private ILogger logger;
        private IMapper mapper;

        public GetAllDeviceStatusQueryHandler(AppDbContext db, ILogger<GetAllDeviceStatusQueryHandler> logger, IMapper mapper)
        {
            this.db = db;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DeviceStatusDto>> Handle(GetAllDeviceStatusQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<DeviceStatusDto>(db.DeviceStatus.AsNoTracking());
        }
    }
}
