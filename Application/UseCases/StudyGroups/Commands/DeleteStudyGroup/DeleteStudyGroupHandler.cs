using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.DeleteStudyGroup
{
    public class DeleteStudyGroupHandler :
        IRequestHandler<DeleteStudyGroupCommand, WereDeletedVm>
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

        public async Task<WereDeletedVm> Handle(DeleteStudyGroupCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _studyGroupsRepository.DeleteAsync(command.Id);

            // Map rows affected
            if (affected > 0)
            {
                return new WereDeletedVm
                {
                    WereDeleted = true,
                    TotalAffected = affected
                };
            }

            return new WereDeletedVm
            {
                WereDeleted = false,
                TotalAffected = 0
            };
        }
    }
}
