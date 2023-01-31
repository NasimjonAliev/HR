using FluentValidation;
using Hr.Application.Models.EducationModels;
using System.Text.RegularExpressions;

namespace Hr.Application.Validators.EducationValidators
{
    public class EducationCreateValidator : AbstractValidator<EducationCreateModel>
    {
        public EducationCreateValidator()
        {
            //var regex = new Regex(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$");

            RuleFor(t => t.UniversityName)
                .NotNull()
                .WithMessage("Заполните название Университета")
                .Length(5, 50);

            RuleFor(t => t.EducationLevel)
                .Length(3, 30);            
        }
    }
}
