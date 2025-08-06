using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Domain.QueryObjects;
using Domain.QueryObjects.Utils;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectHandler :
        IRequestHandler<SearchCoursesByObjectQuery, PaginatedVm<SearchCoursesByObjectVm>>
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

        public async Task<PaginatedVm<SearchCoursesByObjectVm>> Handle(SearchCoursesByObjectQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _coursesRepository.SearchCoursesByObjectAsync(
                new CoursesPaginatedQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new CoursesQueryFilter
                    {
                        Code = query.FilteringCriteria.Code != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Code.Operator,
                            Value = query.FilteringCriteria.Code.Value
                        } : null,
                        Name = query.FilteringCriteria.Name != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Name.Operator,
                            Value = query.FilteringCriteria.Name.Value
                        } : null,
                        Description = query.FilteringCriteria.Description != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Description.Operator,
                            Value = query.FilteringCriteria.Description.Value
                        } : null,
                        CreatedAt = query.FilteringCriteria.CreatedAt != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.CreatedAt.Operator,
                            Value = query.FilteringCriteria.CreatedAt.Value
                        } : null
                    } : null,
                    OrderingCriteria = query.OrderingCriteria != null ? new CoursesQueryOrder
                    {
                        Code = query.OrderingCriteria.Code,
                        Name = query.OrderingCriteria.Name,
                        Description = query.OrderingCriteria.Description,
                        CreatedAt = query.OrderingCriteria.CreatedAt
                    } : null,
                    CurrentPage = query.CurrentPage,
                    PageSize = query.PageSize
                });
            var totalCount = await _coursesRepository.TotalCountCoursesByObjectAsync(
                new CoursesQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new CoursesQueryFilter
                    {
                        Code = query.FilteringCriteria.Code != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Code.Operator,
                            Value = query.FilteringCriteria.Code.Value
                        } : null,
                        Name = query.FilteringCriteria.Name != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Name.Operator,
                            Value = query.FilteringCriteria.Name.Value
                        } : null,
                        Description = query.FilteringCriteria.Description != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Description.Operator,
                            Value = query.FilteringCriteria.Description.Value
                        } : null,
                        CreatedAt = query.FilteringCriteria.CreatedAt != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.CreatedAt.Operator,
                            Value = query.FilteringCriteria.CreatedAt.Value
                        } : null
                    } : null
                });

            // Map result to response
            var items = _mapper.Map<IEnumerable<Course>, IEnumerable<SearchCoursesByObjectVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<SearchCoursesByObjectVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
