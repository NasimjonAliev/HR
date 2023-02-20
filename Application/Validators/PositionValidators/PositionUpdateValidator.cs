using FluentValidation;
using Hr.Application.Models.PositionModels;

namespace Hr.Application.Validators.PositionValodators
{
    public class PositionUpdateValidator : AbstractValidator <PositionUpdateModel>
    {
        public PositionUpdateValidator()
        {
            RuleFor(t => t.Id)
                .NotNull();
            RuleFor(t => t.Amount)
                .NotNull()
                .WithMessage("Заполните поля Name");
            RuleFor(t => t.Amount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
