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
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00001).PropertyName);
            RuleFor(x => x.Name)
                .Length(3, 100)
                .When(x => x.Name != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00002).PropertyName);

            RuleFor(x => x.TeacherId)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00003).PropertyName);
            RuleFor(x => x.TeacherId)
                .GreaterThan(0)
                .When(x => x.TeacherId != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00004).PropertyName);

            RuleFor(x => x.Code)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00005).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00005).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00005).PropertyName);
            RuleFor(x => x.Code)
                .Length(6)
                .When(x => x.Code != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00006).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00006).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00006).PropertyName);

            RuleFor(x => x.Description)
                .NotNull()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00007).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00007).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00007).PropertyName);
            RuleFor(x => x.Description)
                .Length(3, 400)
                .When(x => x.Description != null)
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00008).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00008).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateCourseFormat00008).PropertyName);
        }
    }
}
