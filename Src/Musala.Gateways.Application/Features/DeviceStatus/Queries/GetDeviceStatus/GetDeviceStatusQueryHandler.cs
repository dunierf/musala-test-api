using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Application.Features.DeviceStatus.Queries.GetAllDeviceStatus;
using Musala.Gateways.Application.Features.Todos.Queries.GetTodo;

namespace Musala.Gateways.Application.Features.DeviceStatus.Queries.GetDeviceStatus
{
    public class GetDeviceStatusQueryHandler : IRequestHandler<GetDeviceStatusQuery, DeviceStatusDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;
        public GetDeviceStatusQueryHandler(ILogger<GetTodoQueryHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<DeviceStatusDto> Handle(GetDeviceStatusQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.DeviceStatus.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(DeviceStatus), request.Id);

            return mapper.Map<DeviceStatusDto>(entity);
        }
    }
}
