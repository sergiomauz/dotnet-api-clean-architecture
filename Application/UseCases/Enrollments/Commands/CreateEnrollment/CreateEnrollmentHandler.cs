using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentHandler :
        IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentVm>
    {
        private readonly ILogger<CreateEnrollmentHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        private readonly ICoursesRepository _coursesRepository;
        private readonly IStudentsRepository _studentsRepository;

        public CreateEnrollmentHandler(
            ILogger<CreateEnrollmentHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository,
            ICoursesRepository coursesRepository,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
            _coursesRepository = coursesRepository;
            _studentsRepository = studentsRepository;
        }

        public async Task<CreateEnrollmentVm> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
        {
            // Verify if enrollment exists
            var existingEnrollment = await _enrollmentsRepository.GetEnrollmentsByStudentIdAsync(command.CourseId.Value, command.StudentId.Value);
            if (existingEnrollment != null)
            {
                throw new Exception("Error. Enrollment already exists.");
            }

            // Verify if course exists
            var existingCourse = await _coursesRepository.GetByIdAsync(command.CourseId.Value);
            if (existingCourse == null)
            {
                throw new Exception("Error. Course does not exist.");
            }

            // Verify if student exists
            var existingStudent = await _studentsRepository.GetByIdAsync(command.StudentId.Value);
            if (existingStudent == null)
            {
                throw new Exception("Error. Student does not exist.");
            }

            // Save teacher information
            var newEnrollment = await _enrollmentsRepository.CreateAsync(
                new Enrollment
                {
                    CourseId = command.CourseId,
                    StudentId = command.StudentId
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateEnrollmentVm>(newEnrollment);

            // Return
            return response;
        }
    }
}
