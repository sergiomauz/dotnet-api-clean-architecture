using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Application.Infrastructure.Persistence;


namespace Application.UseCases.Teachers.Queries.GetTeacherById
{
    public class GetTeacherByIdHandler :
        IRequestHandler<GetTeacherByIdQuery, GetTeacherByIdVm>
    {
        private readonly ILogger<GetTeacherByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITeachersRepository _teachersRepository;

        public GetTeacherByIdHandler(
            ILogger<GetTeacherByIdHandler> logger,
            IMapper mapper,
            ITeachersRepository teachersRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _teachersRepository = teachersRepository;
        }

        public async Task<GetTeacherByIdVm> Handle(GetTeacherByIdQuery query, CancellationToken cancellationToken)
        {
            // Get data by Code, if it fails throw exception
            var data = await _teachersRepository.GetByIdAsync(query.Id.Value);
            if (data == null)
            {
                throw new Exception($"Teacher with ID '{query.Id}' does not exist");
            }

            // Map result to response
            var response = _mapper.Map<GetTeacherByIdVm>(data);

            return response;
        }
    }
}
