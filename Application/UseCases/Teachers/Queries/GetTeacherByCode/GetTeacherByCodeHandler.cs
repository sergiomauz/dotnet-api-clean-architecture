using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.GetTeacherByCode
{
    public class GetTeacherByCodeHandler :
        IRequestHandler<GetTeacherByCodeQuery, GetTeacherByCodeVm>
    {
        private readonly ILogger<GetTeacherByCodeHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public GetTeacherByCodeHandler(
            ILogger<GetTeacherByCodeHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<GetTeacherByCodeVm> Handle(GetTeacherByCodeQuery query, CancellationToken cancellationToken)
        {
            // Get data by ID, if it fails throw exception
            var data = await _teachersRepository.GetByCodeAsync(query.Code);
            if (data == null)
            {
                throw new Exception($"Teacher with code '{query.Code}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetTeacherByCodeVm>(data);

            return response;
        }
    }
}
