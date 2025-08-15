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
                .SetValidator(new IdQueryValidator(errorCatalogService));

            RuleFor(x => x.Name)
                .Length(3, 100)
                .When(x => !string.IsNullOrEmpty(x.Name))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00001).PropertyName);

            RuleFor(x => x.TeacherId)
                .GreaterThan(0)
                .When(x => x.TeacherId != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00002).PropertyName);

            RuleFor(x => x.Code)
                .Length(6)
                .When(x => !string.IsNullOrEmpty(x.Code))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00003).PropertyName);

            RuleFor(x => x.Description)
                .Length(3, 400)
                .When(x => !string.IsNullOrEmpty(x.Description))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateCourseFormat00004).PropertyName);
        }
    }
}
