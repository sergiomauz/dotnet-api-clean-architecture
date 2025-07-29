using AutoMapper;
using Commons.Enums;
using Application.Commons.Mapping;


namespace Application.UseCases.Teachers.Queries.SearchTeachersByObject
{
    public class SearchTeachersByObjectOrderingQuery :
        IMapFrom<SearchTeachersByObjectOrderingDto>
    {
        public OrderOperator? Code { get; set; }
        public OrderOperator? Firstname { get; set; }
        public OrderOperator? Lastname { get; set; }
        public OrderOperator? CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SearchTeachersByObjectOrderingDto, SearchTeachersByObjectOrderingQuery>()
                .ForMember(d => d.Code, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Code)))
                .ForMember(d => d.Firstname, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Firstname)))
                .ForMember(d => d.Lastname, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.Lastname)))
                .ForMember(d => d.CreatedAt, m => m.MapFrom(o => EnumHelper.FromDescription<OrderOperator>(o.CreatedAt)));
        }
    }
}
