using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
//using Domain.Entities;
//using Domain.QueryObjects;
//using Domain.QueryObjects.Utils;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.SearchStudentsByObject
{
    public class SearchStudentsByObjectHandler :
        IRequestHandler<SearchStudentsByObjectQuery, PaginatedVm<SearchStudentsByObjectVm>>
    {
        private readonly ILogger<SearchStudentsByObjectHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public SearchStudentsByObjectHandler(
            ILogger<SearchStudentsByObjectHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<PaginatedVm<SearchStudentsByObjectVm>> Handle(SearchStudentsByObjectQuery query, CancellationToken cancellationToken)
        {

        }
    }
}
