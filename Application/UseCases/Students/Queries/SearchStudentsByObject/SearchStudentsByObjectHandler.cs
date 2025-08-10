using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Domain.QueryObjects;
using Domain.QueryObjects.Utils;
using Application.Commons.VMs;
using Application.ErrorCatalog;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.SearchStudentsByObject
{
    public class SearchStudentsByObjectHandler :
        IRequestHandler<SearchStudentsByObjectQuery, PaginatedVm<SearchStudentsByObjectVm>>
    {
        private readonly IErrorCatalogService _errorCatalogService;
        private readonly ILogger<SearchStudentsByObjectHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public SearchStudentsByObjectHandler(
            IErrorCatalogService errorCatalogService,
            ILogger<SearchStudentsByObjectHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _errorCatalogService = errorCatalogService;
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<PaginatedVm<SearchStudentsByObjectVm>> Handle(SearchStudentsByObjectQuery query, CancellationToken cancellationToken)
        {
            // Get results
            var dataList = await _studentsRepository.SearchStudentsByObjectAsync(
                new StudentsPaginatedQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new StudentsQueryFilter
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
                        } : null,
                        BirthDate = query.FilteringCriteria.BirthDate != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.BirthDate.Operator,
                            Value = query.FilteringCriteria.BirthDate.Value
                        } : null
                    } : null,
                    OrderingCriteria = query.OrderingCriteria != null ? new StudentsQueryOrder
                    {
                        Code = query.OrderingCriteria.Code,
                        Firstname = query.OrderingCriteria.Firstname,
                        Lastname = query.OrderingCriteria.Lastname
                    } : null,
                    CurrentPage = query.CurrentPage,
                    PageSize = query.PageSize
                });
            var totalCount = await _studentsRepository.TotalCountStudentsByObjectAsync(
                new StudentsQuery
                {
                    FilteringCriteria = query.FilteringCriteria != null ? new StudentsQueryFilter
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
                        } : null,
                        BirthDate = query.FilteringCriteria.BirthDate != null ? new FilteringCriterion
                        {
                            Operator = query.FilteringCriteria.BirthDate.Operator,
                            Value = query.FilteringCriteria.BirthDate.Value
                        } : null
                    } : null
                });

            // Map result to response
            var items = _mapper.Map<IEnumerable<Student>, IEnumerable<SearchStudentsByObjectVm>>(dataList);

            // Format search results
            var response = new PaginatedVm<SearchStudentsByObjectVm>(
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
