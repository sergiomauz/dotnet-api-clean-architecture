using FluentValidation;
using Application.ErrorCatalog;


namespace Application.UseCases.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00001).PropertyName);
            RuleFor(x => x.Code)
                .Length(3, 10)
                .When(x => !string.IsNullOrEmpty(x.Code))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00002).PropertyName);

            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00003).PropertyName);
            RuleFor(x => x.Firstname)
                .Length(3, 100)
                .When(x => !string.IsNullOrEmpty(x.Firstname))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00004).PropertyName);

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00005).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00005).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00005).PropertyName);
            RuleFor(x => x.Lastname)
                .Length(3, 100)
                .When(x => !string.IsNullOrEmpty(x.Lastname))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00006).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00006).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.CreateTeacherFormat00006).PropertyName);
        }
    }
}
