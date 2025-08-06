using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


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
            // Verify if student exists
            var existingStudent = await _studentsRepository.GetByIdAsync(command.Id.Value);
            if (existingStudent == null)
            {
                throw new Exception("Error. Student does not exist.");
            }

            // Verify which fields to update
            if (!string.IsNullOrEmpty(command.Code))
            {
                // Verify if a valid student code exists and if this is the same to update
                var existingStudentWithCode = await _studentsRepository.GetByCodeAsync(command.Code);
                if (existingStudentWithCode != null)
                {
                    if (existingStudent.Id != existingStudentWithCode.Id)
                    {
                        throw new Exception("Error. Student code already exists.");
                    }
                }
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
            var newStudent = await _studentsRepository.UpdateAsync(existingStudent);

            // Map newData to response
            var response = _mapper.Map<UpdateStudentVm>(newStudent);

            // Return
            return response;
        }
    }
}
