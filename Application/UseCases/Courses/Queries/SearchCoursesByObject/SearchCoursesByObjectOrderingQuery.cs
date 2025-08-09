using AutoMapper;
using Commons.Enums;
using Application.Commons.Mapping;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectOrderingQuery :
        IMapFrom<SearchCoursesByObjectOrderingDto>
    {
        public OrderOperator? Code { get; set; }
        public OrderOperator? Name { get; set; }
        public OrderOperator? Description { get; set; }
        public OrderOperator? CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SearchCoursesByObjectOrderingDto, SearchCoursesByObjectOrderingQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Code) ?? (OrderOperator?)null))
                .ForMember(d => d.Name, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Name) ?? (OrderOperator?)null))
                .ForMember(d => d.Description, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Description) ?? (OrderOperator?)null))
                .ForMember(d => d.CreatedAt, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.CreatedAt) ?? (OrderOperator?)null));
        }
    }
}
