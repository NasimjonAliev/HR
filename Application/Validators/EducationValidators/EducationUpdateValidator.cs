using FluentValidation;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Validators.EducationValidators
{
    public class EducationUpdateValidator : AbstractValidator<EducationUpdateModel>
    {
        public EducationUpdateValidator()
        {
            RuleFor(t => t.UniversityName)
                .NotNull()
                .WithMessage("Заполните название Университета")
                .Length(5, 50);

            RuleFor(t => t.EducationLevel)
                .Length(3, 30);
        }
    }
}