using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;


namespace Application.UseCases.Schools.Commands.CreateSchool
{
    public class CreateSchoolCommand :
        IMapFrom<HttpRequest>,
        IMapFrom<CreateSchoolDto>,
        IRequest<CreateSchoolVm>
    {
        public int TeacherId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, CreateSchoolCommand>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<CreateSchoolDto, CreateSchoolCommand>()
                .ForMember(d => d.TeacherId, m => m.MapFrom(o => o.TeacherId.Value))
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description));
        }
    }
}
