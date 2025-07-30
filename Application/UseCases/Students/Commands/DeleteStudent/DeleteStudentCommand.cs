using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteStudentRoute>,
        IRequest<DeleteStudentVm>
    {
        public string? Id { get; set; }

        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteStudentCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteStudentRoute, DeleteStudentCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
