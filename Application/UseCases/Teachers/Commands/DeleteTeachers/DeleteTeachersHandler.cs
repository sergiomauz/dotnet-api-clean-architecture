using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Commands.DeleteTeachers
{
    public class DeleteTeachersHandler :
        IRequestHandler<DeleteTeachersCommand, DeleteTeachersVm>
    {
        private readonly ILogger<DeleteTeachersHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public DeleteTeachersHandler(
            ILogger<DeleteTeachersHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<DeleteTeachersVm> Handle(DeleteTeachersCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _teachersRepository.DeleteAsync(command.Id.Value);

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteTeachersVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteTeachersVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
