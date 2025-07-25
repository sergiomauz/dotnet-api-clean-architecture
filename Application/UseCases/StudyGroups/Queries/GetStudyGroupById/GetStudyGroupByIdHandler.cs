using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupById
{
    public class GetStudyGroupByIdHandler :
        IRequestHandler<GetStudyGroupByIdQuery, GetStudyGroupByIdVm>
    {
        private readonly ILogger<GetStudyGroupByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _studyGroupsRepository;

        public GetStudyGroupByIdHandler(
            ILogger<GetStudyGroupByIdHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository studyGroupsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studyGroupsRepository = studyGroupsRepository;
        }

        public async Task<GetStudyGroupByIdVm> Handle(GetStudyGroupByIdQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _studyGroupsRepository.GetByIdAsync(Convert.ToInt32(query.Id));
            if (data == null)
            {
                throw new Exception($"Study Group with ID '{query.Id}' does not exist");
            }

            // Map reult to response
            var response = _mapper.Map<GetStudyGroupByIdVm>(data);

            return response;
        }
    }
}
