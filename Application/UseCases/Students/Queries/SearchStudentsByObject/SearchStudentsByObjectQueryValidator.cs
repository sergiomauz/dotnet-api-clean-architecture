using FluentValidation;
using Commons.Enums;
using Commons.Helpers;
using Application.Commons.Validators;
using Application.ErrorCatalog;


namespace Application.UseCases.Students.Queries.SearchStudentsByObject
{
    public class SearchStudentsByObjectQueryValidator : AbstractValidator<SearchStudentsByObjectQuery>
    {
        public SearchStudentsByObjectQueryValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x)
                .SetValidator(new PaginatedQueryValidator(errorCatalogService));

            RuleFor(x => x.FilteringCriteria)
                .ChildRules(fc =>
                {
                    fc.RuleFor(c => c.Code)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00001).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00001).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00001).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Code.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Code?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00002).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00002).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00002).PropertyName);
                        });

                    fc.RuleFor(c => c.Firstname)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00003).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00003).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00003).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Firstname.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Firstname?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00004).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00004).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00004).PropertyName);
                        });

                    fc.RuleFor(c => c.Lastname)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00005).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00005).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00005).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.Lastname.Operand)
                                .Must(v => JsonElementValidators.IsValidString(v, max: 10))
                                .When(c => c.Lastname?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00006).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00006).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00006).PropertyName);
                        });

                    fc.RuleFor(c => c.BirthDate)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00007).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00007).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00007).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.BirthDate.Operand)
                                .Must(v => JsonElementValidators.IsValidDateTime(v))
                                .When(c => c.BirthDate?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00008).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00008).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00008).PropertyName);
                        });

                    fc.RuleFor(c => c.CreatedAt)
                        .Must(v => FilteringCriterionQueryValidator.IsValid(v))
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00009).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00009).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00009).PropertyName)
                        .DependentRules(() =>
                        {
                            fc.RuleFor(c => c.CreatedAt.Operand)
                                .Must(v => JsonElementValidators.IsValidDateTime(v))
                                .When(c => c.CreatedAt?.Operand != null)
                                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00010).ErrorCode)
                                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00010).ErrorMessage)
                                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00010).PropertyName);
                        });
                })
                .When(x => x.FilteringCriteria != null);

            RuleFor(x => x.OrderingCriteria)
                .ChildRules(oc =>
                {
                    oc.RuleFor(c => c.Code)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Code != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00011).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00011).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00011).PropertyName);

                    oc.RuleFor(c => c.Firstname)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Firstname != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00012).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00012).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00012).PropertyName);

                    oc.RuleFor(c => c.Lastname)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.Lastname != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00013).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00013).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00013).PropertyName);

                    oc.RuleFor(c => c.BirthDate)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.BirthDate != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00014).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00014).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00014).PropertyName);

                    oc.RuleFor(c => c.CreatedAt)
                        .Must(v => EnumHelper.IsValidDescription<OrderOperator>(v))
                        .When(c => c.CreatedAt != null)
                        .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00015).ErrorCode)
                        .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00015).ErrorMessage)
                        .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.SearchStudentsByObjectFormat00015).PropertyName);
                })
                .When(x => x.OrderingCriteria != null);
        }
    }
}
