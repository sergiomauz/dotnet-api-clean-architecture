using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Teachers.Queries.GetTeacherByCode
{
    public class GetTeacherByCodeQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetTeacherByCodeRoute>,
        IRequest<GetTeacherByCodeVm>
    {
        public string? Code { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetTeacherByCodeQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetTeacherByCodeRoute, GetTeacherByCodeQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code));
        }
    }
}
