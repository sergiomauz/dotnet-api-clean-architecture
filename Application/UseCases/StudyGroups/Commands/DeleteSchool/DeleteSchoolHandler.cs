using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Commons.VMs;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.DeleteSchool
{
    public class DeleteSchoolHandler :
        IRequestHandler<DeleteSchoolCommand, WereDeletedVm>
    {
        private readonly ILogger<DeleteSchoolHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _schoolsRepository;

        public DeleteSchoolHandler(
            ILogger<DeleteSchoolHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository schoolsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _schoolsRepository = schoolsRepository;
        }

        public async Task<WereDeletedVm> Handle(DeleteSchoolCommand command, CancellationToken cancellationToken)
        {
            // Delete rows
            var affected = await _schoolsRepository.DeleteAsync(command.Id);

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
