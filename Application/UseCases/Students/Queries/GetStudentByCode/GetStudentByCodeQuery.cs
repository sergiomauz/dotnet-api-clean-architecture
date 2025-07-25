using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Students.Queries.GetStudentByCode
{
    public class GetStudentByCodeQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetStudentByCodeRoute>,
        IRequest<GetStudentByCodeVm>
    {
        public string? Code { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetStudentByCodeQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetStudentByCodeRoute, GetStudentByCodeQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code));
        }
    }
}
