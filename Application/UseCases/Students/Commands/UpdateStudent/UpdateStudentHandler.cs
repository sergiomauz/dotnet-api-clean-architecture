using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.UseCases.Students.Commands.UpdateStudent
{
    public class UpdateStudentHandler :
        IRequestHandler<UpdateStudentCommand, UpdateStudentVm>
    {
        private readonly ILogger<UpdateStudentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public UpdateStudentHandler(
            ILogger<UpdateStudentHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<UpdateStudentVm> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            // Verify if teacher exists
            var existingStudent = await _studentsRepository.GetByIdAsync(command.Id);
            if (existingStudent == null)
            {
                throw new Exception("Error. Student does not exist.");
            }

            // Verify which fields to update
            if (!string.IsNullOrEmpty(command.Code))
            {
                existingStudent.Code = command.Code;
            }
            if (!string.IsNullOrEmpty(command.Firstname))
            {
                existingStudent.Firstname = command.Firstname;
            }
            if (!string.IsNullOrEmpty(command.Lastname))
            {
                existingStudent.Lastname = command.Lastname;
            }
            if (command.BirthDate.HasValue)
            {
                existingStudent.BirthDate = command.BirthDate.Value;
            }

            // Save student information
            var newStudent = await _studentsRepository.UpdateAsync(
                new Student
                {
                    Id = existingStudent.Id,
                    Code = existingStudent.Code,
                    Firstname = existingStudent.Firstname,
                    Lastname = existingStudent.Lastname,
                    BirthDate = existingStudent.BirthDate,
                    CreatedAt = existingStudent.CreatedAt
                }
            );

            // Map newData to response
            var response = _mapper.Map<UpdateStudentVm>(newStudent);

            // Return
            return response;
        }
    }
}
