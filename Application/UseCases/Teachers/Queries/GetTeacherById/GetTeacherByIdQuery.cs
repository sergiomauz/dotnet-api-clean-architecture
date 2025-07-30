using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Teachers.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetTeacherByIdRoute>,
        IRequest<GetTeacherByIdVm>
    {
        public int? Id { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetTeacherByIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetTeacherByIdRoute, GetTeacherByIdQuery>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
