using FluentValidation;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Validators.StaffValidators
{
    public class StaffCreateValidator : AbstractValidator <StaffCreateModel>
    {
        public StaffCreateValidator()
        {
            RuleFor(t => t.UserId)
                .NotEmpty()
                .WithMessage("Поля UserId не должна быть пустым");

            RuleFor(t => t.PositionId)
                .NotEmpty()
                .WithMessage("Поля PositionId не должна быть пустым");

            RuleFor(t => t.EducationId)
                .NotEmpty()
                .WithMessage("Поля EducationId не должна быть пустым");
        }
    }
}
