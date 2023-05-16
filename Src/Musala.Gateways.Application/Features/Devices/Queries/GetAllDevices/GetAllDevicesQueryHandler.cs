using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices
{
    public class GetAllDevicesQueryHandler : IRequestHandler<GetAllDevicesQuery, IEnumerable<DeviceDto>>
    {
        private AppDbContext db;
        private ILogger logger;
        private IMapper mapper;

        public GetAllDevicesQueryHandler(AppDbContext db, ILogger<GetAllDevicesQueryHandler> logger, IMapper mapper)
        {
            this.db = db;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDto>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<DeviceDto>(db.Devices.Where(c => c.GatewayId == request.Id).AsNoTracking());
        }
    }
}
