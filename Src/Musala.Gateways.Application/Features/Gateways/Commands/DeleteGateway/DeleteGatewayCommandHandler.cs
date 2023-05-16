using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Musala.Gateways.Application.Common.Exceptions;
using Musala.Gateways.Domain.Entities.Gateways;
using Musala.Gateways.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Musala.Gateways.Application.Features.Gateways.Commands.DeleteGateway
{
    public class DeleteGatewayCommandHandler : IRequestHandler<DeleteGatewayCommand>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public DeleteGatewayCommandHandler(ILogger<DeleteGatewayCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGatewayCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.Gateways.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Gateway), request.Id);

            db.Gateways.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Task.Result;
        }
    }
}
