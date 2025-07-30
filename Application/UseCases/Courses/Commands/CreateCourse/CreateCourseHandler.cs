using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Commands.CreateCourse
{
    public class CreateCourseHandler :
        IRequestHandler<CreateCourseCommand, CreateCourseVm>
    {
        private readonly ILogger<CreateCourseHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;
        private readonly ITeachersRepository _teachersRepository;

        public CreateCourseHandler(
            ILogger<CreateCourseHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<CreateCourseVm> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            // Verify if course exists
            var existingCourse = await _coursesRepository.GetByCodeAsync(command.Code);
            if (existingCourse != null)
            {
                throw new Exception("Error. Course already exists.");
            }

            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId.Value);
            if (existingTeacher == null)
            {
                throw new Exception("Error. Teacher does not exist.");
            }

            // Save course information
            var newCourse = await _coursesRepository.CreateAsync(
                new Course
                {
                    TeacherId = command.TeacherId,
                    Code = command.Code,
                    Name = command.Name,
                    Description = command.Description
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateCourseVm>(newCourse);

            // Return
            return response;
        }
    }
}
