using FluentValidation;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Validators.EducationValidators
{
    public class EducationCreateValidator : AbstractValidator<EducationCreateModel>
    {
        public EducationCreateValidator()
        {
            RuleFor(t => t.UniversityName)
                .NotNull()
                .WithMessage("Заполните название Университета")
                .MaximumLength(50);

            RuleFor(t => t.EducationLevel)
                .Length(3, 30);

            RuleFor(t => t.StartedAt)
                .Must(CheckDate)
                .WithMessage("поля StartedAt начинается с 2000 года");

            RuleFor(t => t.FinishedAt)
                .Must(CheckDate)
                .WithMessage("поля FinishedAt начинается с 2000 года");

        }

        public static bool CheckDate(DateTime date)
        {
            return date.Year > 2000;
        }
    }
}
