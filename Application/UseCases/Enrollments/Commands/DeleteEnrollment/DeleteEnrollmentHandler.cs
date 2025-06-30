using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentHandler :
        IRequestHandler<DeleteEnrollmentCommand, WereDeletedVm>
    {
        private readonly ILogger<DeleteEnrollmentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public DeleteEnrollmentHandler(
            ILogger<DeleteEnrollmentHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
        }

        public async Task<WereDeletedVm> Handle(DeleteEnrollmentCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _enrollmentsRepository.DeleteAsync(command.Id);

            // Map rows affected
            if (affected > 0)
            {
                return new WereDeletedVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new WereDeletedVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
