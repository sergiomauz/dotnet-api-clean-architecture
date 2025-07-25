using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Courses.Queries.GetCourseByCode
{
    public class GetCourseByCodeQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetCourseByCodeRoute>,
        IRequest<GetCourseByCodeVm>
    {
        public string? Code { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetCourseByCodeQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetCourseByCodeRoute, GetCourseByCodeQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code));
        }
    }
}
