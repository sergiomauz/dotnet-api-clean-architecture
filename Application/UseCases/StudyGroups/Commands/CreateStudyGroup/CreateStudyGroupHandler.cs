using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.CreateStudyGroup
{
    public class CreateStudyGroupHandler :
        IRequestHandler<CreateStudyGroupCommand, CreateStudyGroupVm>
    {
        private readonly ILogger<CreateStudyGroupHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _studyGroupsRepository;
        private readonly ITeachersRepository _teachersRepository;

        public CreateStudyGroupHandler(
            ILogger<CreateStudyGroupHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository studyGroupsRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studyGroupsRepository = studyGroupsRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<CreateStudyGroupVm> Handle(CreateStudyGroupCommand command, CancellationToken cancellationToken)
        {
            // Verify if study group exists
            var existingStudyGroup = await _studyGroupsRepository.GetByCodeAsync(command.Code);
            if (existingStudyGroup != null)
            {
                throw new Exception("Error. Study group already exists.");
            }

            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId);
            if (existingTeacher == null)
            {
                throw new Exception("Error. Teacher does not exist.");
            }

            // Save study group information
            var newStudyGroup = await _studyGroupsRepository.CreateAsync(
                new StudyGroup
                {
                    TeacherId = command.TeacherId,
                    Code = command.Code,
                    Name = command.Name,
                    Description = command.Description
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateStudyGroupVm>(newStudyGroup);

            // Return
            return response;
        }
    }
}
