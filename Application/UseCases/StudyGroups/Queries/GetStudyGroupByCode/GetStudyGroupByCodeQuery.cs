using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupByCode
{
    public class GetStudyGroupByCodeQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetStudyGroupByCodeRoute>,
        IRequest<GetStudyGroupByCodeVm>
    {
        public string? Code { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetStudyGroupByCodeQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetStudyGroupByCodeRoute, GetStudyGroupByCodeQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code));
        }
    }
}
