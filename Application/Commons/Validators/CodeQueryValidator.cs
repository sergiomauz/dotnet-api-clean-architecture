using FluentValidation;
using Application.Commons.Queries;
using Application.ErrorCatalog;


namespace Application.Commons.Validators
{
    public class CodeQueryValidator :
        AbstractValidator<CodeQuery>
    {
        public CodeQueryValidator(IErrorCatalogService errorCatalogService)
        {

        }
    }
}
