using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.GetCoursesByStudentId
{
    public class GetCoursesByStudentIdHandler :
        IRequestHandler<GetCoursesByStudentIdQuery, PaginatedVm<GetCoursesByStudentIdVm>>
    {
        private readonly ILogger<GetCoursesByStudentIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public GetCoursesByStudentIdHandler(
            ILogger<GetCoursesByStudentIdHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
        }

        public async Task<PaginatedVm<GetCoursesByStudentIdVm>> Handle(GetCoursesByStudentIdQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _enrollmentsRepository.GetCoursesByStudentIdAsync(query.StudentId.Value,
                                                                                    query.CurrentPage.Value,
                                                                                    query.PageSize.Value);
            var totalCount = await _enrollmentsRepository.TotalCountCoursesByStudentIdAsync(query.StudentId.Value);

            // Map result to response
            var items = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<GetCoursesByStudentIdVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<GetCoursesByStudentIdVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
