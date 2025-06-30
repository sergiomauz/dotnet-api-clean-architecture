using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Domain;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Schools.Commands.CreateSchool
{
    public class CreateSchoolHandler :
        IRequestHandler<CreateSchoolCommand, CreateSchoolVm>
    {
        private readonly ILogger<CreateSchoolHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISchoolsRepository _schoolsRepository;
        private readonly ITeachersRepository _teachersRepository;

        public CreateSchoolHandler(
            ILogger<CreateSchoolHandler> logger,
            IMapper mapper,
            ISchoolsRepository schoolsRepository,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _schoolsRepository = schoolsRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<CreateSchoolVm> Handle(CreateSchoolCommand command, CancellationToken cancellationToken)
        {
            // Verify if school exists
            var existingSchool = await _schoolsRepository.GetByCodeAsync(command.Code);
            if (existingSchool != null)
            {
                throw new Exception("Error. School already exists.");
            }

            // Verify if teacher exists
            var existingTeacher = await _teachersRepository.GetByIdAsync(command.TeacherId);
            if (existingSchool != null)
            {
                throw new Exception("Error. Teacher does not exist.");
            }

            // Save school information
            var newSchool = await _schoolsRepository.CreateAsync(
                new School
                {
                    TeacherId = command.TeacherId,
                    Code = command.Code,
                    Name = command.Name,
                    Description = command.Description
                }
            );

            // Map newData to response
            var response = _mapper.Map<CreateSchoolVm>(newSchool);

            // Return
            return response;
        }
    }
}
