using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.StudyGroups.Commands.CreateSchool
{
    public class CreateStudyGroupHandler :
        IRequestHandler<CreateStudyGroupCommand, CreateStudyGroupVm>
    {
        private readonly ILogger<CreateStudyGroupHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudyGroupsRepository _schoolsRepository;
        private readonly ITeachersRepository _teachersRepository;

        public CreateStudyGroupHandler(
            ILogger<CreateStudyGroupHandler> logger,
            IMapper mapper,
            IStudyGroupsRepository schoolsRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _schoolsRepository = schoolsRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<CreateStudyGroupVm> Handle(CreateStudyGroupCommand command, CancellationToken cancellationToken)
        {
            // Verify if school exists
            var existingSchool = await _schoolsRepository.GetByCodeAsync(command.Code);
            if (existingSchool != null)
            {
                throw new Exception("Error. School already exists.");
            }

            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId);
            if (existingTeacher == null)
            {
                throw new Exception("Error. Teacher does not exist.");
            }

            // Save school information
            var newSchool = await _schoolsRepository.CreateAsync(
                new StudyGroup
                {
                    TeacherId = command.TeacherId,
                    Code = command.Code,
                    Name = command.Name,
                    Description = command.Description
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateStudyGroupVm>(newSchool);

            // Return
            return response;
        }
    }
}
