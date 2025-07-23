using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<DeleteEnrollmentRoute>,
        IRequest<DeleteEnrollmentVm>
    {
        public int Id { get; set; }

        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, DeleteEnrollmentCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<DeleteEnrollmentRoute, DeleteEnrollmentCommand>()
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id.Value));
        }
    }
}
