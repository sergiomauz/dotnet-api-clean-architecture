using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.VMs;


namespace Application.UseCases.StudyGroups.Commands.DeleteSchool
{
    public class DeleteSchoolCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteSchoolRoute>,
        IRequest<WereDeletedVm>
    {
        public int Id { get; set; }

        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteSchoolCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteSchoolRoute, DeleteSchoolCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id.Value));
        }
    }
}
