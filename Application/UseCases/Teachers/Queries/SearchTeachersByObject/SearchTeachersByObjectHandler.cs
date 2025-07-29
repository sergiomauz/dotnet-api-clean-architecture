using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
//using Domain.Entities;
//using Domain.QueryObjects;
//using Domain.QueryObjects.Utils;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.SearchTeachersByObject
{
    public class SearchTeachersByObjectHandler :
        IRequestHandler<SearchTeachersByObjectQuery, PaginatedVm<SearchTeachersByObjectVm>>
    {
        private readonly ILogger<SearchTeachersByObjectHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public SearchTeachersByObjectHandler(
            ILogger<SearchTeachersByObjectHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<PaginatedVm<SearchTeachersByObjectVm>> Handle(SearchTeachersByObjectQuery query, CancellationToken cancellationToken)
        {

        }
    }
}
