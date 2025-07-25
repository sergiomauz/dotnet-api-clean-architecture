using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupByCode
{
    public class GetStudyGroupByCodeHandler :
        IRequestHandler<GetStudyGroupByCodeQuery, GetStudyGroupByCodeVm>
    {
        private readonly ILogger<GetStudyGroupByCodeHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _studyGroupsRepository;

        public GetStudyGroupByCodeHandler(
            ILogger<GetStudyGroupByCodeHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository studyGroupsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studyGroupsRepository = studyGroupsRepository;
        }

        public async Task<GetStudyGroupByCodeVm> Handle(GetStudyGroupByCodeQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _studyGroupsRepository.GetByCodeAsync(query.Code);
            if (data == null)
            {
                throw new Exception($"Teacher with code '{query.Code}' does not exist");
            }

            // Map reult to response
            var response = _mapper.Map<GetStudyGroupByCodeVm>(data);

            return response;
        }
    }
}
