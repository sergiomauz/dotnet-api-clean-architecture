using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.RequestParams;
using Application.Commons.VMs;


namespace Application.UseCases.Students.Queries.GetCoursesByStudentId
{
    public class GetCoursesByStudentIdQuery :
        PaginationRequestParams,
        IMapFrom<HttpRequest>,
        IMapFrom<GetCoursesByStudentIdRoute>,
        IRequest<PagerVm<GetCoursesByStudentIdVm>>
    {
        public string? StudentId { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetCoursesByStudentIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetCoursesByStudentIdRoute, GetCoursesByStudentIdQuery>()
                .ForMember(d => d.StudentId, m => m.MapFrom(o => o.StudentId));

            profile.CreateMap<PaginationRequestParams, GetCoursesByStudentIdQuery>()
                .ForMember(d => d.CurrentPage, m => m.MapFrom(o => o.CurrentPage))
                .ForMember(d => d.PageSize, m => m.MapFrom(o => o.PageSize));
        }
    }
}
