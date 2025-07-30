using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.Queries;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand :
        IdQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteTeacherRoute>,
        IRequest<DeleteTeacherVm>
    {
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteTeacherCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteTeacherRoute, DeleteTeacherCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
