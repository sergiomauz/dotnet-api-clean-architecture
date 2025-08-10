using FluentValidation;
using Application.Commons.Queries;
using Application.ErrorCatalog;


namespace Application.Commons.Validators
{
    public class IdsQueryValidator : AbstractValidator<IdsQuery>
    {
        public IdsQueryValidator(IErrorCatalogService errorCatalogService)
        {
            // Almost one of them is null
            RuleFor(x => x)
                .Must(x => x.Id.HasValue || (x.Ids != null && x.Ids.Any()))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00001).PropertyName);

            // Almost one of them has a not null value
            RuleFor(x => x)
                .Must(x => !(x.Id.HasValue && x.Ids != null && x.Ids.Any()))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00002).PropertyName);

            // Id must be greater than zero
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .When(x => x.Id.HasValue)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00003).PropertyName);

            // Ids must have more than one element if it is not null
            RuleFor(x => x.Ids)
                .NotEmpty()
                .When(x => !x.Id.HasValue)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00004).PropertyName);

            // Every element of Ids must be greater than zero
            RuleForEach(x => x.Ids)
                .GreaterThan(0)
                .When(x => !x.Id.HasValue && x.Ids != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00005).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00005).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00005).PropertyName);

            // Ids must avoid duplicate elements
            RuleFor(x => x.Ids)
                .Must(ids => ids == null || ids.Count() == ids.Distinct().Count())
                .When(x => !x.Id.HasValue && x.Ids != null && x.Ids.Any())
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00006).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00006).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.IdsFormat00006).PropertyName);
        }
    }
}
