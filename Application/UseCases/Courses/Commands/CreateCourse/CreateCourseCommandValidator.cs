using FluentValidation;
using Application.ErrorCatalog;


namespace Application.UseCases.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00001).PropertyName);
            RuleFor(x => x.Name)
                .Length(3, 100)
                .When(x => x.Name != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00002).PropertyName);

            RuleFor(x => x.TeacherId)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00003).PropertyName);
            RuleFor(x => x.TeacherId)
                .GreaterThan(0)
                .When(x => x.TeacherId != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00004).PropertyName);

            RuleFor(x => x.Code)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00005).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00005).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00005).PropertyName);
            RuleFor(x => x.Code)
                .Length(6)
                .When(x => x.Code != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00006).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00006).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00006).PropertyName);

            RuleFor(x => x.Description)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00007).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00007).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00007).PropertyName);
            RuleFor(x => x.Description)
                .Length(3, 400)
                .When(x => x.Description != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00008).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00008).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseErrorFormat00008).PropertyName);
        }
    }
}
