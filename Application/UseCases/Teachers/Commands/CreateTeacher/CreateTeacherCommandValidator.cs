using FluentValidation;


namespace Application.UseCases.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(x => x.Firstname)
                .NotNull()
                .WithErrorCode("val00001")
                .WithMessage("val00001.MessageToClient")
                .OverridePropertyName("firstname");
            RuleFor(x => x.Firstname)
                .Length(3, 100)
                .When(x => x.Firstname != null)
                .WithErrorCode("val00002")
                .WithMessage("val00002.MessageToClient")
                .OverridePropertyName("firstname");

            RuleFor(x => x.Lastname)
                .NotNull()
                .WithErrorCode("val00003")
                .WithMessage("val00003.MessageToClient")
                .OverridePropertyName("lastname");
            RuleFor(x => x.Lastname)
                .Length(3, 100)
                .When(x => x.Lastname != null)
                .WithErrorCode("val00004")
                .WithMessage("val00004.MessageToClient")
                .OverridePropertyName("lastname");
        }
    }
}
