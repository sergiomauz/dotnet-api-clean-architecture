using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.UpdateStudyGroup
{
    public class UpdateStudyGroupHandler :
        IRequestHandler<UpdateStudyGroupCommand, UpdateStudyGroupVm>
    {
        private readonly ILogger<UpdateStudyGroupHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _studyGroupsRepository;
        private readonly ITeachersRepository _teachersRepository;

        public UpdateStudyGroupHandler(
            ILogger<UpdateStudyGroupHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository studyGroupsRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studyGroupsRepository = studyGroupsRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<UpdateStudyGroupVm> Handle(UpdateStudyGroupCommand command, CancellationToken cancellationToken)
        {
            // Verify if study group exists
            var existingStudyGroup = await _studyGroupsRepository.GetByIdAsync(command.Id);
            if (existingStudyGroup == null)
            {
                throw new Exception("Error. Study group does not exist.");
            }

            // Verify which fields to update
            if (!string.IsNullOrEmpty(command.Code))
            {
                // Verify if a valid study group code exists and if this is the same to update
                var existingStudyGroupWithCode = await _studyGroupsRepository.GetByCodeAsync(command.Code);
                if (existingStudyGroupWithCode != null)
                {
                    if (existingStudyGroup.Id != existingStudyGroupWithCode.Id)
                    {
                        throw new Exception("Error. Study group code already exists.");
                    }
                }
                existingStudyGroup.Code = command.Code;
            }
            if (command.TeacherId.HasValue)
            {
                // Verify if teacher exists
                var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId.Value);
                if (existingTeacher == null)
                {
                    throw new Exception("Error. Teacher does not exist.");
                }
                existingStudyGroup.TeacherId = command.TeacherId;
            }
            if (!string.IsNullOrEmpty(command.Name))
            {
                existingStudyGroup.Name = command.Name;
            }
            if (!string.IsNullOrEmpty(command.Name))
            {
                existingStudyGroup.Name = command.Name;
            }

            // Save study group information
            var newStudyGroup = await _studyGroupsRepository.UpdateAsync(existingStudyGroup);

            // Map newData to response
            var response = _mapper.Map<UpdateStudyGroupVm>(newStudyGroup);

            // Return
            return response;
        }
    }
}
