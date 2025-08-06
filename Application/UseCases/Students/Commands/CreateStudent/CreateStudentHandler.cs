using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Commands.CreateStudent
{
    public class CreateStudentHandler :
        IRequestHandler<CreateStudentCommand, CreateStudentVm>
    {
        private readonly ILogger<CreateStudentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public CreateStudentHandler(
            ILogger<CreateStudentHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<CreateStudentVm> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            // Verify if student exists
            var existingStudent = await _studentsRepository.GetByCodeAsync(command.Code);
            if (existingStudent != null)
            {
                throw new Exception("Error. Student already exists.");
            }

            // Save student information
            var newTeacher = await _studentsRepository.CreateAsync(
                new Student
                {
                    Code = command.Code,
                    Firstname = command.Firstname,
                    Lastname = command.Lastname,
                    BirthDate = command.BirthDate
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateStudentVm>(newTeacher);

            // Return
            return response;
        }
    }
}
