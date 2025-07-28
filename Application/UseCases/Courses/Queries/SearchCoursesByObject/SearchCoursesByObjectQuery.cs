using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Application.Commons.Mapping;
using Application.Commons.RequestParams;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectFilteringQuery
    {
        public FilteringCriterion? Code { get; set; }
        public FilteringCriterion? Name { get; set; }
        public FilteringCriterion? Description { get; set; }
    }

    public class SearchCoursesByObjectOrderingQuery
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class SearchCoursesByObjectQuery :
        IMapFrom<HttpRequest>,
        IMapFrom<SearchCoursesByObjectDto>,
        IRequest<SearchCoursesByObjectVm>
    {
        public SearchCoursesByObjectFilteringQuery? FilteringCriteria { get; set; }
        public SearchCoursesByObjectOrderingQuery? OrderingCriteria { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public HttpRequest? Request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequest, SearchCoursesByObjectQuery>()
                .ForMember(d => d.Request, m => m.MapFrom(o => o));

            profile.CreateMap<SearchCoursesByObjectFilteringDto, SearchCoursesByObjectFilteringQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description));

            profile.CreateMap<SearchCoursesByObjectOrderingDto, SearchCoursesByObjectOrderingQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => o.Code))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description));

            profile.CreateMap<SearchCoursesByObjectDto, SearchCoursesByObjectQuery>()
                .ForMember(d => d.PageSize, m => m.MapFrom(o => o.PageSize))
                .ForMember(d => d.CurrentPage, m => m.MapFrom(o => o.CurrentPage))
                .ForMember(d => d.FilteringCriteria, m => m.MapFrom(o => o.FilteringCriteria))
                .ForMember(d => d.OrderingCriteria, m => m.MapFrom(o => o.OrderingCriteria));
        }
    }
}
