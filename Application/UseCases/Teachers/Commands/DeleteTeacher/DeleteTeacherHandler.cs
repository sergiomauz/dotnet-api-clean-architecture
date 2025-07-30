using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherHandler :
        IRequestHandler<DeleteTeacherCommand, DeleteTeacherVm>
    {
        private readonly ILogger<DeleteTeacherHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public DeleteTeacherHandler(
            ILogger<DeleteTeacherHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<DeleteTeacherVm> Handle(DeleteTeacherCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _teachersRepository.DeleteAsync(command.Id.Value);

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteTeacherVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteTeacherVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
