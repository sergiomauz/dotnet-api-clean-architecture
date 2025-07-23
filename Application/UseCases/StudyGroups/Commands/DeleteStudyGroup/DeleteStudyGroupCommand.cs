using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.VMs;


namespace Application.UseCases.StudyGroups.Commands.DeleteStudyGroup
{
    public class DeleteStudyGroupCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteStudyGroupRoute>,
        IRequest<WereDeletedVm>
    {
        public int Id { get; set; }

        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteStudyGroupCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteStudyGroupRoute, DeleteStudyGroupCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id.Value));
        }
    }
}
