using Application.Commons.Mapping;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Application.UseCases.StudyGroups.Commands.UpdateStudyGroup
{
    public class UpdateStudyGroupCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<UpdateStudyGroupDto>,
        IMapFrom<UpdateStudyGroupRoute>,
        IRequest<UpdateStudyGroupVm>
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, UpdateStudyGroupCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<UpdateStudyGroupRoute, UpdateStudyGroupCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));

            profile.CreateMap<UpdateStudyGroupDto, UpdateStudyGroupCommand>()
                .ForMember(d => d.TeacherId, m => m.MapFrom(o => o.TeacherId.Value))
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description));
        }
    }
}
