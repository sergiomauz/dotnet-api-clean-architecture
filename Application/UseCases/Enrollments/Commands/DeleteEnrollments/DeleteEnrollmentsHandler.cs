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
            var affected = await _enrollmentsRepository.DeleteAsync(Convert.ToInt32(command.Id));

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteEnrollmentsVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
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
