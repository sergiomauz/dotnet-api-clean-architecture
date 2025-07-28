using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.Queries;
using Application.Commons.VMs;


namespace Application.UseCases.Teachers.Queries.GetStudentsByTeacherId
{
    public class GetStudentsByTeacherIdQuery :
        PaginationQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<GetStudentsByTeacherIdRoute>,
        IMapFrom<GetStudentsByTeacherIdRequestParams>,
        IRequest<PaginationVm<GetStudentsByTeacherIdVm>>
    {
        public string? TeacherId { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetStudentsByTeacherIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetStudentsByTeacherIdRoute, GetStudentsByTeacherIdQuery>()
                .ForMember(d => d.TeacherId, m => m.MapFrom(o => o.TeacherId));

            profile.CreateMap<GetStudentsByTeacherIdRequestParams, GetStudentsByTeacherIdQuery>()
                .ForMember(d => d.CurrentPage, m => m.MapFrom(o => o.CurrentPage))
                .ForMember(d => d.PageSize, m => m.MapFrom(o => o.PageSize));
        }
    }
}
