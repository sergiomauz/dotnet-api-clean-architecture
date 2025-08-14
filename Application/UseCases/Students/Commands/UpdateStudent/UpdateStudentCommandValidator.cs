using System.Globalization;
using FluentValidation;
using Application.Commons.Validators;
using Application.ErrorCatalog;


namespace Application.UseCases.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator(IErrorCatalogService errorCatalogService)
        {
            RuleFor(x => x)
                .SetValidator(new IdsQueryValidator(errorCatalogService));

            RuleFor(x => x.Code)
                .Length(3, 10)
                .When(x => !string.IsNullOrEmpty(x.Code))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00001).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00001).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00001).PropertyName);

            RuleFor(x => x.Firstname)
                .Length(3, 100)
                .When(x => !string.IsNullOrEmpty(x.Firstname))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00002).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00002).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00002).PropertyName);

            RuleFor(x => x.Lastname)
                .Length(3, 100)
                .When(x => !string.IsNullOrEmpty(x.Lastname))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00003).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00003).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00003).PropertyName);

            RuleFor(x => x.BirthDate)
                .Must(v => DateTime.TryParseExact(v, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                .When(x => !string.IsNullOrEmpty(x.BirthDate))
                .WithErrorCode(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00004).ErrorCode)
                .WithMessage(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00004).ErrorMessage)
                .OverridePropertyName(errorCatalogService.GetErrorByCode(ErrorConstants.UpdateStudentFormat00004).PropertyName);
        }
    }
}
