using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentHandler :
        IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentVm>
    {
        private readonly ILogger<CreateEnrollmentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        private readonly ISchoolsRepository _schoolsRepository;
        private readonly IStudentsRepository _studentsRepository;

        public CreateEnrollmentHandler(
            ILogger<CreateEnrollmentHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository,
            ISchoolsRepository schoolsRepository,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
            _schoolsRepository = schoolsRepository;
            _studentsRepository = studentsRepository;
        }

        public async Task<CreateEnrollmentVm> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
        {
            // Verify if school exists
            var existingSchool = await _schoolsRepository.GetByIdAsync(command.SchoolId);
            if (existingSchool == null)
            {
                throw new Exception("Error. School does not exist.");
            }

            // Verify if student exists
            var existingStudent = await _studentsRepository.GetByIdAsync(command.StudentId);
            if (existingStudent == null)
            {
                throw new Exception("Error. Student does not exist.");
            }

            // Verify if enrollment exists
            var existingEnrollment = await _enrollmentsRepository.GetEnrollmentByStudentIdAsync(command.SchoolId, command.StudentId);
            if (existingEnrollment != null)
            {
                throw new Exception("Error. Enrollment already exists.");
            }

            // Save teacher information
            var newTeacher = await _enrollmentsRepository.CreateAsync(
                new Enrollment
                {
                    SchoolId = command.SchoolId,
                    StudentId = command.StudentId
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateEnrollmentVm>(newTeacher);

            // Return
            return response;
        }
    }
}
