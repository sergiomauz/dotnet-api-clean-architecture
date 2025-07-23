using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.DeleteStudyGroup
{
    public class DeleteStudyGroupHandler :
        IRequestHandler<DeleteStudyGroupCommand, DeleteStudyGroupVm>
    {
        private readonly ILogger<DeleteStudyGroupHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _studyGroupsRepository;

        public DeleteStudyGroupHandler(
            ILogger<DeleteStudyGroupHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository studyGroupsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studyGroupsRepository = studyGroupsRepository;
        }

        public async Task<DeleteStudyGroupVm> Handle(DeleteStudyGroupCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _studyGroupsRepository.DeleteAsync(command.Id);

            // Map rows affected
            if (affected > 0)
            {
                return new DeleteStudyGroupVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new DeleteStudyGroupVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
