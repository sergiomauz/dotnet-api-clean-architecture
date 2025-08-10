using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Domain.QueryObjects;
using Domain.QueryObjects.Utils;
using Application.ErrorCatalog;
using Application.Infrastructure.Persistence;
using Application.Commons.VMs;


namespace Application.UseCases.Teachers.Queries.SearchTeachersByObject
{
    public class SearchTeachersByObjectHandler :
        IRequestHandler<SearchTeachersByObjectQuery, PaginatedVm<SearchTeachersByObjectVm>>
    {
        private readonly IErrorCatalogService _errorCatalogService;
        private readonly ILogger<SearchTeachersByObjectHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public SearchTeachersByObjectHandler(
            IErrorCatalogService errorCatalogService,
            ILogger<SearchTeachersByObjectHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _errorCatalogService = errorCatalogService;
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<PaginatedVm<SearchTeachersByObjectVm>> Handle(SearchTeachersByObjectQuery query, CancellationToken cancellationToken)
        {
            // Get results
            var dataList = await _teachersRepository.SearchTeachersByObjectAsync(
                new TeachersPaginatedQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new TeachersQueryFilter
                    {
                        Code = query.FilteringCriteria.Code != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Code.Operator,
                            Value = query.FilteringCriteria.Code.Value
                        } : null,
                        Firstname = query.FilteringCriteria.Firstname != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Firstname.Operator,
                            Value = query.FilteringCriteria.Firstname.Value
                        } : null,
                        Lastname = query.FilteringCriteria.Lastname != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Lastname.Operator,
                            Value = query.FilteringCriteria.Lastname.Value
                        } : null
                    } : null,
                    OrderingCriteria = query.OrderingCriteria != null ? new TeachersQueryOrder
                    {
                        Code = query.OrderingCriteria.Code,
                        Firstname = query.OrderingCriteria.Firstname,
                        Lastname = query.OrderingCriteria.Lastname
                    } : null,
                    CurrentPage = query.CurrentPage,
                    PageSize = query.PageSize
                });
            var totalCount = await _teachersRepository.TotalCountTeachersByObjectAsync(
                new TeachersQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new TeachersQueryFilter
                    {
                        Code = query.FilteringCriteria.Code != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Code.Operator,
                            Value = query.FilteringCriteria.Code.Value
                        } : null,
                        Firstname = query.FilteringCriteria.Firstname != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Firstname.Operator,
                            Value = query.FilteringCriteria.Firstname.Value
                        } : null,
                        Lastname = query.FilteringCriteria.Lastname != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.Lastname.Operator,
                            Value = query.FilteringCriteria.Lastname.Value
                        } : null
                    } : null
                });

            // Map result to response
            var items = _mapper.Map<IEnumerable<Teacher>, IEnumerable<SearchTeachersByObjectVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<SearchTeachersByObjectVm>(
                    items,
                    totalCount,
                    query.CurrentPage.Value,
                    query.PageSize.Value
                );

            //
            return response;
        }
    }
}
