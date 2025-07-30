using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.Queries;


namespace Application.UseCases.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand :
        IdQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteCourseRoute>,
        IRequest<DeleteCourseVm>
    {
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteCourseCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteCourseRoute, DeleteCourseCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
