using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Queries.GetCourseById
{
    public class GetCourseByIdHandler :
        IRequestHandler<GetCourseByIdQuery, GetCourseByIdVm>
    {
        private readonly ILogger<GetCourseByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public GetCourseByIdHandler(
            ILogger<GetCourseByIdHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<GetCourseByIdVm> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _coursesRepository.GetByIdAsync(Convert.ToInt32(query.Id));
            if (data == null)
            {
                throw new Exception($"Course with ID '{query.Id}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetCourseByIdVm>(data);

            return response;
        }
    }
}
