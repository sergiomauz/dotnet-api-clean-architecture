using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Students.Queries.GetStudentByCode
{
    public class GetStudentByCodeHandler :
        IRequestHandler<GetStudentByCodeQuery, GetStudentByCodeVm>
    {
        private readonly ILogger<GetStudentByCodeHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public GetStudentByCodeHandler(
            ILogger<GetStudentByCodeHandler> logger,
            IMapper mapper,
            IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<GetStudentByCodeVm> Handle(GetStudentByCodeQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _studentsRepository.GetByCodeAsync(query.Code);
            if (data == null)
            {
                throw new Exception($"Student with code '{query.Code}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetStudentByCodeVm>(data);

            return response;
        }
    }
}
