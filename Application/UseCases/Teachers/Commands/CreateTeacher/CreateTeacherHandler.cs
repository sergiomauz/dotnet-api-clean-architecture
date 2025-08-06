using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherHandler :
        IRequestHandler<CreateTeacherCommand, CreateTeacherVm>
    {
        private readonly ILogger<CreateTeacherHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public CreateTeacherHandler(
            ILogger<CreateTeacherHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<CreateTeacherVm> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
        {
            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByCodeAsync(command.Code);
            if (existingTeacher != null)
            {
                throw new Exception("Error. Teacher already exists.");
            }

            // Save teacher information
            var newTeacher = await _teachersRepository.CreateAsync(
                new Teacher
                {
                    Code = command.Code,
                    Firstname = command.Firstname,
                    Lastname = command.Lastname
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateTeacherVm>(newTeacher);

            // Return
            return response;
        }
    }
}
