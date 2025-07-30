using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.SearchTeachersByTextFilter
{
    public class SearchTeachersByTextFilterHandler :
        IRequestHandler<SearchTeachersByTextFilterQuery, PaginatedVm<SearchTeachersByTextFilterVm>>
    {
        private readonly ILogger<SearchTeachersByTextFilterHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public SearchTeachersByTextFilterHandler(
            ILogger<SearchTeachersByTextFilterHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<PaginatedVm<SearchTeachersByTextFilterVm>> Handle(SearchTeachersByTextFilterQuery query, CancellationToken cancellationToken)
        {
            // Set default values for searching
            if (query.CurrentPage == null) query.CurrentPage = 1;
            if (query.PageSize == null) query.PageSize = 20;

            // Get results
            var dataList = await _teachersRepository.SearchTeachersByTextFilterAsync(query.TextFilter,
                                                                                     query.CurrentPage.Value,
                                                                                     query.PageSize.Value);
            var totalCount = await _teachersRepository.TotalCountTeachersByTextFilterAsync(query.TextFilter);

            // Map result to response
            var items = _mapper.Map<IEnumerable<Teacher>, IEnumerable<SearchTeachersByTextFilterVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<SearchTeachersByTextFilterVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            return response;
        }
    }
}
