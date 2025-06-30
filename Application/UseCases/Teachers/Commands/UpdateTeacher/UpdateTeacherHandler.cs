using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherHandler :
        IRequestHandler<UpdateTeacherCommand, UpdateTeacherVm>
    {
        private readonly ILogger<UpdateTeacherHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public UpdateTeacherHandler(
            ILogger<UpdateTeacherHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<UpdateTeacherVm> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
        {
            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByIdAsync(command.Id);
            if (existingTeacher == null)
            {
                throw new Exception("Error. Teacher does not exist.");
            }

            // Verify which fields to update
            if (!string.IsNullOrEmpty(command.Code))
            {
                existingTeacher.Code = command.Code;
            }
            if (!string.IsNullOrEmpty(command.Firstname))
            {
                existingTeacher.Firstname = command.Firstname;
            }
            if (!string.IsNullOrEmpty(command.Lastname))
            {
                existingTeacher.Lastname = command.Lastname;
            }

            // Save teacher information
            var newTeacher = await _teachersRepository.UpdateAsync(
                new Teacher
                {
                    Id = existingTeacher.Id,
                    Code = existingTeacher.Code,
                    Firstname = existingTeacher.Firstname,
                    Lastname = existingTeacher.Lastname,
                    CreatedAt = existingTeacher.CreatedAt
                }
            );

            // Map newData to response
            var response = _mapper.Map<UpdateTeacherVm>(newTeacher);

            // Return
            return response;
        }
    }
}
