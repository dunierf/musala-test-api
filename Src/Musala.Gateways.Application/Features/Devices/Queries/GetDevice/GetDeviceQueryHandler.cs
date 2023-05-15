using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Domain.Entities.Devices;
using Musala.Gateways.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Devices.Queries.GetDevice
{
    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public GetDeviceQueryHandler(ILogger<GetDeviceQueryHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<DeviceDto> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Devices.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Device), request.Id);

            return mapper.Map<DeviceDto>(entity);
        }
    }
}
