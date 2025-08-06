using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Commands.UpdateCourse
{
    public class UpdateCourseHandler :
        IRequestHandler<UpdateCourseCommand, UpdateCourseVm>
    {
        private readonly ILogger<UpdateCourseHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;
        private readonly ITeachersRepository _teachersRepository;

        public UpdateCourseHandler(
            ILogger<UpdateCourseHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<UpdateCourseVm> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            // Verify if course exists
            var existingCourse = await _coursesRepository.GetByIdAsync(Convert.ToInt32(command.Id));
            if (existingCourse == null)
            {
                throw new Exception("Error. Course does not exist.");
            }

            // Verify which fields to update
            if (!string.IsNullOrEmpty(command.Code))
            {
                // Verify if a valid course code exists and if this is the same to update
                var existingCourseWithCode = await _coursesRepository.GetByCodeAsync(command.Code);
                if (existingCourseWithCode != null)
                {
                    if (existingCourse.Id != existingCourseWithCode.Id)
                    {
                        throw new Exception("Error. Course code already exists.");
                    }
                }
                existingCourse.Code = command.Code;
            }
            if (command.TeacherId.HasValue)
            {
                // Verify if teacher exists
                var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId.Value);
                if (existingTeacher == null)
                {
                    throw new Exception("Error. Teacher does not exist.");
                }
                existingCourse.TeacherId = Convert.ToInt32(command.TeacherId);
            }
            if (!string.IsNullOrEmpty(command.Name))
            {
                existingCourse.Name = command.Name;
            }
            if (!string.IsNullOrEmpty(command.Name))
            {
                existingCourse.Name = command.Name;
            }

            // Save course information
            var newCourse = await _coursesRepository.UpdateAsync(existingCourse);

            // Map newData to response
            var response = _mapper.Map<UpdateCourseVm>(newCourse);

            // Return
            return response;
        }
    }
}
