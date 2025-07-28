using Application.Commons.VMs;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entities;
using Domain.QueryObjects;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectHandler :
        IRequestHandler<SearchCoursesByObjectQuery, PaginationVm<SearchCoursesByObjectVm>>
    {

        private readonly ILogger<SearchCoursesByObjectHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public SearchCoursesByObjectHandler(
            ILogger<SearchCoursesByObjectHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<PaginationVm<SearchCoursesByObjectVm>> Handle(SearchCoursesByObjectQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _coursesRepository.SearchCoursesByObjectAsync(
                new CoursesPaginatedQuery
                {
                });
            var totalCount = await _coursesRepository.TotalCountCoursesByObjectAsync(
                new CoursesQuery
                {
                });

            // Map result to response
            var items = _mapper.Map<IEnumerable<Course>, IEnumerable<SearchCoursesByObjectVm>>(dataList);

            // Format search results
            var response = new PaginationVm<SearchCoursesByObjectVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }

    }
}
