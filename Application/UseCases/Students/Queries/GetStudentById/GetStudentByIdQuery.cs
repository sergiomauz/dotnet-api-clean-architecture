using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<GetStudentByIdRoute>,
        IRequest<GetStudentByIdVm>
    {
        public string? Id { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, GetStudentByIdQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<GetStudentByIdRoute, GetStudentByIdQuery>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));
        }
    }
}
