using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.Queries;


namespace Application.UseCases.Courses.Commands.DeleteCourses
{
    public class DeleteCoursesCommand :
        IdQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteCoursesRoute>,
        IRequest<DeleteCoursesVm>
    {
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteCoursesCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteCoursesRoute, DeleteCoursesCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
