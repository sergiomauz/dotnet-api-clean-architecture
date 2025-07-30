using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.Queries;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollments
{
    public class DeleteEnrollmentsCommand :
        IdsQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteEnrollmentsRoute>,
        IMapFrom<DeleteEnrollmentsDto>,
        IRequest<DeleteEnrollmentsVm>
    {
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteEnrollmentsCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteEnrollmentsRoute, DeleteEnrollmentsCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id));

            profile.CreateMap<DeleteEnrollmentsDto, DeleteEnrollmentsCommand>()
                .ForMember(d => d.Ids, m => m.MapFrom(o => o.Ids));
        }
    }
}
