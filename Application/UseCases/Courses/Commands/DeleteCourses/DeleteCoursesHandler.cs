using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Commands.DeleteCourses
{
    public class DeleteCoursesHandler :
        IRequestHandler<DeleteCoursesCommand, DeleteCoursesVm>
    {
        private readonly ILogger<DeleteCoursesHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public DeleteCoursesHandler(
            ILogger<DeleteCoursesHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<DeleteCoursesVm> Handle(DeleteCoursesCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _coursesRepository.DeleteAsync(Convert.ToInt32(command.Id));

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteCoursesVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteCoursesVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
