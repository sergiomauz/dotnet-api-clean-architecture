using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Commands.DeleteCourse
{
    public class DeleteCourseHandler :
        IRequestHandler<DeleteCourseCommand, DeleteCourseVm>
    {
        private readonly ILogger<DeleteCourseHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public DeleteCourseHandler(
            ILogger<DeleteCourseHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<DeleteCourseVm> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _coursesRepository.DeleteAsync(command.Id);

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteCourseVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteCourseVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
