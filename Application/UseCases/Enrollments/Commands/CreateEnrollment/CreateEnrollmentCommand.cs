using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<CreateEnrollmentDto>,
        IRequest<CreateEnrollmentVm>
    {
        public int SchoolId { get; set; }
        public int StudentId { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, CreateEnrollmentCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<CreateEnrollmentDto, CreateEnrollmentCommand>()
                .ForMember(d => d.SchoolId, m => m.MapFrom(o => o.SchoolId.Value))
                .ForMember(d => d.StudentId, m => m.MapFrom(o => o.StudentId.Value));
        }
    }
}
