using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Commands.DeleteStudent
{
    public class DeleteStudentHandler :
        IRequestHandler<DeleteStudentCommand, WereDeletedVm>
    {
        private readonly ILogger<DeleteStudentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public DeleteStudentHandler(
            ILogger<DeleteStudentHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<WereDeletedVm> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _studentsRepository.DeleteAsync(command.Id);

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
