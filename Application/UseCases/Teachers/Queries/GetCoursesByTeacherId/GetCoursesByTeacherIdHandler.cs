using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;
using Domain.Entities;


namespace Application.UseCases.Teachers.Queries.GetCoursesByTeacherId
{
    public class GetCoursesByTeacherIdHandler :
        IRequestHandler<GetCoursesByTeacherIdQuery, PaginationVm<GetCoursesByTeacherIdVm>>
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

        public async Task<PaginationVm<GetCoursesByTeacherIdVm>> Handle(GetCoursesByTeacherIdQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _coursesRepository.GetCoursesByTeacherIdAsync(Convert.ToInt32(query.TeacherId),
                                                                     query.CurrentPage.Value,
                                                                     query.PageSize.Value);
            var totalCount = await _coursesRepository.TotalCoursesByTeacherIdAsync(Convert.ToInt32(query.TeacherId));

            // Map result to response
            var items = _mapper.Map<IEnumerable<Course>, IEnumerable<GetCoursesByTeacherIdVm>>(dataList);

            // Format search results
            var response = new PaginationVm<GetCoursesByTeacherIdVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
