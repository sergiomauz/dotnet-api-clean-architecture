using Microsoft.Extensions.Logging;
using AutoMapper;
using Domain;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.GetCoursesByStudentId
{
    public class GetCoursesByStudentIdHandler :
        IRequestHandler<GetCoursesByStudentIdQuery, PagerVm<GetCoursesByStudentIdVm>>
    {
        private readonly ILogger<GetCoursesByStudentIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public GetCoursesByStudentIdHandler(
            ILogger<GetCoursesByStudentIdHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<PagerVm<GetCoursesByStudentIdVm>> Handle(GetCoursesByStudentIdQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _studentsRepository.GetCoursesByStudentId(Convert.ToInt32(query.StudentId),
                                                                     query.CurrentPage.Value,
                                                                     query.PageSize.Value);
            var totalCount = await _studentsRepository.TotalCountCoursesByStudentIdAsync(Convert.ToInt32(query.StudentId));

            // Map reult to response
            var items = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<GetCoursesByStudentIdVm>>(dataList);

            // Format search results
            var response = new PagerVm<GetCoursesByStudentIdVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
