using Application.Commons.VMs;
using Application.Infrastructure.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherHandler :
        IRequestHandler<DeleteTeacherCommand, WereDeletedVm>
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

        public async Task<WereDeletedVm> Handle(DeleteTeacherCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _teachersRepository.DeleteAsync(command.Id);

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
