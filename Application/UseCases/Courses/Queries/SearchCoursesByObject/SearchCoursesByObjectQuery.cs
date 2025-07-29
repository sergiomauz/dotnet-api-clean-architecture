using Microsoft.AspNetCore.Http;
using AutoMapper;
using MediatR;
using Commons.Enums;
using Application.Commons.Mapping;
using Application.Commons.Queries;
using Application.Commons.VMs;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectFilteringQuery
    {
        public FilteringCriterionQuery? Code { get; set; }
        public FilteringCriterionQuery? Name { get; set; }
        public FilteringCriterionQuery? Description { get; set; }
    }

    public class SearchCoursesByObjectOrderingQuery
    {
        public OrderOperator? Code { get; set; }
        public OrderOperator? Name { get; set; }
        public OrderOperator? Description { get; set; }
    }

    public class SearchCoursesByObjectQuery :
        PaginatedQuery,
        IMapFrom<HttpRequest>,
        IMapFrom<SearchCoursesByObjectDto>,
        IRequest<PaginatedVm<SearchCoursesByObjectVm>>
    {
        public SearchCoursesByObjectFilteringQuery? FilteringCriteria { get; set; }
        public SearchCoursesByObjectOrderingQuery? OrderingCriteria { get; set; }
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
                .ForMember(d => d.Code, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Code)))
                .ForMember(d => d.Name, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Name)))
                .ForMember(d => d.Description, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Description)));

            profile.CreateMap<SearchCoursesByObjectDto, SearchCoursesByObjectQuery>()
                .ForMember(d => d.PageSize, m => m.MapFrom(o => o.PageSize))
                .ForMember(d => d.CurrentPage, m => m.MapFrom(o => o.CurrentPage))
                .ForMember(d => d.FilteringCriteria, m => m.MapFrom(o => o.FilteringCriteria))
                .ForMember(d => d.OrderingCriteria, m => m.MapFrom(o => o.OrderingCriteria));
        }
    }
}
