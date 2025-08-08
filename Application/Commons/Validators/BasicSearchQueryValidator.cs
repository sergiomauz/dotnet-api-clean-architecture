using FluentValidation;
using Application.Commons.Queries;
using Application.ErrorCatalog;


namespace Application.Commons.Validators
{
    public class BasicSearchQueryValidator : AbstractValidator<BasicSearchQuery>
    {
        public BasicSearchQueryValidator(IErrorCatalogService errorCatalogService)
        {

        }
    }
}
