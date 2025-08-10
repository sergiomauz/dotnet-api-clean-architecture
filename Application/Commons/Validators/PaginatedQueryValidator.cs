using FluentValidation;
using Application.Commons.Queries;
using Application.ErrorCatalog;


namespace Application.Commons.Validators
{
    public class PaginatedQueryValidator : AbstractValidator<PaginatedQuery>
    {
        public PaginatedQueryValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x.CurrentPage)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00001).PropertyName);
            RuleFor(x => x.CurrentPage)
                .GreaterThan(0)
                .When(x => x.CurrentPage != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00002).PropertyName);

            RuleFor(x => x.PageSize)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00003).PropertyName);
            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .When(x => x.PageSize != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.PaginatedFormat00004).PropertyName);
        }
    }
}
