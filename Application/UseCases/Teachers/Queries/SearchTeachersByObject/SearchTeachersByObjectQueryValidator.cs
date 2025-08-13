using FluentValidation;
using Commons.Enums;
using Commons.Helpers;
using Application.Commons.Validators;
using Application.ErrorCatalog;


namespace Application.UseCases.Teachers.Queries.SearchTeachersByObject
{
    public class SearchTeachersByObjectQueryValidator : AbstractValidator<SearchTeachersByObjectQuery>
    {
        public SearchTeachersByObjectQueryValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x)
                .SetValidator(new PaginatedQueryValidator(errorCatalogService));

            RuleFor(x => x.FilteringCriteria)
                .ChildRules(fc =>
                {
                    fc.RuleFor(c => c.Code)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00001).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00001).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00001).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Code.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Code?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00002).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00002).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00002).PropertyName);
                        });

                    fc.RuleFor(c => c.Firstname)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .When(c => c.Firstname != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00003).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00003).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00003).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Firstname.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Firstname?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00004).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00004).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00004).PropertyName);
                        });

                    fc.RuleFor(c => c.Lastname)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00005).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00005).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00005).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Lastname.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Lastname?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00006).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00006).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00006).PropertyName);
                        });

                    fc.RuleFor(c => c.CreatedAt)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00007).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00007).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00007).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.CreatedAt.Operand)
                                .Must(v => JsonElementValidators.IsValidDateTime(v))
                                .When(c => c.CreatedAt?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00008).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00008).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00008).PropertyName);
                        });
                })
                .When(x => x.FilteringCriteria != null);

            RuleFor(x => x.OrderingCriteria)
                .ChildRules(oc =>
                {
                    oc.RuleFor(c => c.Code)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Code != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00009).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00009).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00009).PropertyName);

                    oc.RuleFor(c => c.Firstname)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Firstname != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00010).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00010).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00010).PropertyName);

                    oc.RuleFor(c => c.Lastname)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Lastname != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00011).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00011).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00011).PropertyName);

                    oc.RuleFor(c => c.CreatedAt)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.CreatedAt != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00012).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00012).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchTeachersByObjectFormat00012).PropertyName);
                })
                .When(x => x.OrderingCriteria != null);
        }
    }
}
