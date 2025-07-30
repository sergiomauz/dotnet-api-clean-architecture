using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Commands.DeleteStudents
{
    public class DeleteStudentsHandler :
        IRequestHandler<DeleteStudentsCommand, DeleteStudentsVm>
    {
        private readonly ILogger<DeleteStudentsHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public DeleteStudentsHandler(
            ILogger<DeleteStudentsHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<DeleteStudentsVm> Handle(DeleteStudentsCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _studentsRepository.DeleteAsync(command.Id.Value);

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteStudentsVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteStudentsVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
