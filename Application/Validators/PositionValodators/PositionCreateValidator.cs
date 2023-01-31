using FluentValidation;
using Hr.Application.Models.PositionModels;

namespace Hr.Application.Validators.PositionValodators
{
    public class PositionCreateValidator : AbstractValidator <PositionCreateModel>
    {
        public PositionCreateValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .WithMessage("Заполните поля Name");
            RuleFor(t => t.Amount)
                .NotNull()
                .LessThan(0);
        }
    }
}
