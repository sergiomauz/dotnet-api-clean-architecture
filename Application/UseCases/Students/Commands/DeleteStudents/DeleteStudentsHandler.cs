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
            var affectedRows = 0;
            if (command.Id != null)
            {
                affectedRows = await _studentsRepository.DeleteAsync(command.Id.Value);
            }
            else if (command.Ids != null)
            {
                affectedRows = await _studentsRepository.DeleteAsync(command.Ids);
            }

            // Map rows affected
            if (affectedRows > 0)
            {
                return new DeleteStudentsVm
                {
                    WereDeleted = true,
                    TotalAffected = affectedRows
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
