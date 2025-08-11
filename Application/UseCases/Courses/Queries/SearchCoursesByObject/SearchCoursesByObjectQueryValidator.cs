using FluentValidation;
using Commons.Enums;
using Application.Commons.Validators;
using Application.ErrorCatalog;


namespace Application.UseCases.Courses.Queries.SearchCoursesByObject
{
    public class SearchCoursesByObjectQueryValidator : AbstractValidator<SearchCoursesByObjectQuery>
    {
        public SearchCoursesByObjectQueryValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x)
                .SetValidator(new PaginatedQueryValidator(errorCatalogService));

            RuleFor(x => x.FilteringCriteria)
                .ChildRules(fc =>
                {
                    fc.RuleFor(c => c.Code)
                        .Must(c => FilteringCriterionQueryValidator.IsValid(c))
                        .When(c => c.Code != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00001).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00001).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00001).PropertyName);

                    fc.RuleFor(c => c.Name)
                        .Must(c => FilteringCriterionQueryValidator.IsValid(c))
                        .When(c => c.Name != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00002).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00002).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00002).PropertyName);

                    fc.RuleFor(c => c.Description)
                        .Must(c => FilteringCriterionQueryValidator.IsValid(c))
                        .When(c => c.Description != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00003).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00003).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00003).PropertyName);

                    fc.RuleFor(c => c.CreatedAt)
                        .Must(c => FilteringCriterionQueryValidator.IsValid(c))
                        .When(c => c.CreatedAt != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00004).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00004).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00004).PropertyName);
                })
                .When(x => x.FilteringCriteria != null);

            RuleFor(x => x.OrderingCriteria)
                .ChildRules(oc =>
                {
                    oc.RuleFor(c => c.Code)
                        .Must(c => Enum.IsDefined(typeof(OrderOperator), c))
                        .When(c => c.Code != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00005).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00005).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00005).PropertyName);

                    oc.RuleFor(c => c.Name)
                        .Must(c => Enum.IsDefined(typeof(OrderOperator), c))
                        .When(c => c.Name != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00006).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00006).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00006).PropertyName);

                    oc.RuleFor(c => c.Description)
                        .Must(c => Enum.IsDefined(typeof(OrderOperator), c))
                        .When(c => c.Description != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00007).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00007).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00007).PropertyName);

                    oc.RuleFor(c => c.CreatedAt)
                        .Must(c => Enum.IsDefined(typeof(OrderOperator), c))
                        .When(c => c.CreatedAt != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00008).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00008).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchCoursesByObjectQueryFormat00008).PropertyName);
                })
                .When(x => x.OrderingCriteria != null);
        }
    }
}
