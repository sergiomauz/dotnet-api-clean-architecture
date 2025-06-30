using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.VMs;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteTeacherRoute>,
        IRequest<WereDeletedVm>
    {
        public int Id { get; set; }

        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteTeacherCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteTeacherRoute, DeleteTeacherCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id.Value));
        }
    }
}
