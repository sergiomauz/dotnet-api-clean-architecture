using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Queries.GetCourseByCode
{
    public class GetCourseByCodeHandler :
        IRequestHandler<GetCourseByCodeQuery, GetCourseByCodeVm>
    {
        private readonly ILogger<GetCourseByCodeHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public GetCourseByCodeHandler(
            ILogger<GetCourseByCodeHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<GetCourseByCodeVm> Handle(GetCourseByCodeQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _coursesRepository.GetByCodeAsync(query.Code);
            if (data == null)
            {
                throw new Exception($"Teacher with code '{query.Code}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetCourseByCodeVm>(data);

            return response;
        }
    }
}
