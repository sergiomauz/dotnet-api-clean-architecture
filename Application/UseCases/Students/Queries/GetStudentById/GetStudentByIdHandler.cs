using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.GetStudentById
{
    public class GetStudentByIdHandler :
        IRequestHandler<GetStudentByIdQuery, GetStudentByIdVm>
    {
        private readonly ILogger<GetStudentByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public GetStudentByIdHandler(
            ILogger<GetStudentByIdHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<GetStudentByIdVm> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _studentsRepository.GetByIdAsync(query.Id.Value);
            if (data == null)
            {
                throw new Exception($"Student with Id '{query.Id}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetStudentByIdVm>(data);

            return response;
        }
    }
}
