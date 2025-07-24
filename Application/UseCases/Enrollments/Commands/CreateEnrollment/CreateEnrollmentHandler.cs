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
        private readonly IStudyGroupsRepository _studyGroupsRepository;
        private readonly IStudentsRepository _studentsRepository;

        public CreateEnrollmentHandler(
            ILogger<CreateEnrollmentHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository,
            IStudyGroupsRepository studyGroupsRepository,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
            _studyGroupsRepository = studyGroupsRepository;
            _studentsRepository = studentsRepository;
        }

        public async Task<CreateEnrollmentVm> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
        {
            // Verify if enrollment exists
            var existingEnrollment = await _enrollmentsRepository.GetEnrollmentByStudentIdAsync(command.StudyGroupId, command.StudentId);
            if (existingEnrollment != null)
            {
                throw new Exception("Error. Enrollment already exists.");
            }

            // Verify if study group exists
            var existingStudyGroup = await _studyGroupsRepository.GetByIdAsync(command.StudyGroupId);
            if (existingStudyGroup == null)
            {
                throw new Exception("Error. Study group does not exist.");
            }

            // Verify if student exists
            var existingStudent = await _studentsRepository.GetByIdAsync(command.StudentId);
            if (existingStudent == null)
            {
                throw new Exception("Error. Student does not exist.");
            }

            // Save teacher information
            var newEnrollment = await _enrollmentsRepository.CreateAsync(
                new Enrollment
                {
                    StudyGroupId = command.StudyGroupId,
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
