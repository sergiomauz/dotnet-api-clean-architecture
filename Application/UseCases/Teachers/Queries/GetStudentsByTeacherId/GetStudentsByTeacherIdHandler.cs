using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.GetStudentsByTeacherId
{
    public class GetStudentsByTeacherIdHandler :
        IRequestHandler<GetStudentsByTeacherIdQuery, PaginatedVm<GetStudentsByTeacherIdVm>>
    {
        private readonly ILogger<GetStudentsByTeacherIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public GetStudentsByTeacherIdHandler(
            ILogger<GetStudentsByTeacherIdHandler> logger,
            IMapper mapper,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _enrollmentsRepository = enrollmentsRepository;
        }

        public async Task<PaginatedVm<GetStudentsByTeacherIdVm>> Handle(GetStudentsByTeacherIdQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _enrollmentsRepository.GetStudentsByTeacherIdAsync(query.TeacherId.Value,
                                                                                     query.CurrentPage.Value,
                                                                                     query.PageSize.Value);
            var totalCount = await _enrollmentsRepository.TotalCountStudentsByTeacherIdAsync(query.TeacherId.Value);

            // Map result to response
            var items = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<GetStudentsByTeacherIdVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<GetStudentsByTeacherIdVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
