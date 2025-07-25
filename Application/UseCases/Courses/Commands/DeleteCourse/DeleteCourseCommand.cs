using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteCourseRoute>,
        IRequest<DeleteCourseVm>
    {
        public int Id { get; set; }

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
