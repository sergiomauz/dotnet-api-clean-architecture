using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.VMs;


namespace Application.UseCases.Teachers.Queries.GetCoursesByTeacherId
{
    public class GetCoursesByTeacherIdQuery :
        GetCoursesByTeacherIdParams,
        IMapFrom<HttpRequest>,
        IMapFrom<GetCoursesByTeacherIdRoute>,
        IRequest<PagerVm<GetCoursesByTeacherIdVm>>
    {
        public string? TeacherId { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetCoursesByTeacherIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetCoursesByTeacherIdRoute, GetCoursesByTeacherIdQuery>()
                .ForMember(d => d.TeacherId, m => m.MapFrom(o => o.TeacherId));

            profile.CreateMap<GetCoursesByTeacherIdParams, GetCoursesByTeacherIdQuery>()
                .ForMember(d => d.CurrentPage, m => m.MapFrom(o => o.CurrentPage))
                .ForMember(d => d.PageSize, m => m.MapFrom(o => o.PageSize));
        }
    }
}
