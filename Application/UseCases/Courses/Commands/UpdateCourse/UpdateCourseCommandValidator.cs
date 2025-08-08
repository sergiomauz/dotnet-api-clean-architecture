using FluentValidation;
using Application.Commons.Validators;
using Application.ErrorCatalog;


namespace Application.UseCases.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x)
                .SetValidator(new IdsQueryValidator(errorCatalogService));
        }
    }
}
