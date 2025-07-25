using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupById
{
    public class GetStudyGroupByIdQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetStudyGroupByIdRoute>,
        IRequest<GetStudyGroupByIdVm>
    {
        public string? Id { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetStudyGroupByIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetStudyGroupByIdRoute, GetStudyGroupByIdQuery>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
