using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollments
{
    public class DeleteEnrollmentsHandler :
        IRequestHandler<DeleteEnrollmentsCommand, DeleteEnrollmentsVm>
    {
        private readonly ILogger<DeleteEnrollmentsHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public DeleteEnrollmentsHandler(
            ILogger<DeleteEnrollmentsHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
        }

        public async Task<DeleteEnrollmentsVm> Handle(DeleteEnrollmentsCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affectedRows = 0;
            if (command.Id != null)
            {
                affectedRows = await _enrollmentsRepository.DeleteAsync(command.Id.Value);
            }
            else if (command.Ids != null)
            {
                affectedRows = await _enrollmentsRepository.DeleteAsync(command.Ids);
            }

            // Map rows affected
            if (affectedRows > 0)
            {
                return new DeleteEnrollmentsVm
                {
                    WereDeleted = true,
                    TotalAffected = affectedRows
                };
            }

            return new DeleteEnrollmentsVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
