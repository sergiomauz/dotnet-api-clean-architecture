using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.GetCoursesByTeacherId
{
    public class GetCoursesByTeacherIdHandler :
        IRequestHandler<GetCoursesByTeacherIdQuery, PaginatedVm<GetCoursesByTeacherIdVm>>
    {
        private readonly ILogger<GetCoursesByTeacherIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public GetCoursesByTeacherIdHandler(
            ILogger<GetCoursesByTeacherIdHandler> logger,
            IMapper mapper,
            ICoursesRepository coursesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<PaginatedVm<GetCoursesByTeacherIdVm>> Handle(GetCoursesByTeacherIdQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _coursesRepository.GetCoursesByTeacherIdAsync(query.TeacherId.Value,
                                                                                 query.CurrentPage.Value,
                                                                                 query.PageSize.Value);
            var totalCount = await _coursesRepository.TotalCoursesByTeacherIdAsync(Convert.ToInt32(query.TeacherId));

            // Map result to response
            var items = _mapper.Map<IEnumerable<Course>, IEnumerable<GetCoursesByTeacherIdVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<GetCoursesByTeacherIdVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
