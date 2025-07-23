using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.StudyGroups.Commands.CreateStudyGroup
{
    public class CreateStudyGroupCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<CreateStudyGroupDto>,
        IRequest<CreateStudyGroupVm>
    {
        public int TeacherId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, CreateStudyGroupCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<CreateStudyGroupDto, CreateStudyGroupCommand>()
                .ForMember(d => d.TeacherId, m => m.MapFrom(o => o.TeacherId.Value))
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description));
        }
    }
}
