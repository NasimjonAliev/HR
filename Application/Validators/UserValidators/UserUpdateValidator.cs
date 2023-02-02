using FluentValidation;
using Hr.Application.Models.UserModels;
using System.Text.RegularExpressions;

namespace Hr.Application.Validators.UserValidators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateModel>
    {
        public UserUpdateValidator()
        {
            var regex = new Regex(@"((992){1}\d{9}|(7){1}\d{10}){1}");

            //TODO разделение валидаций по дочерним

            RuleFor(h => h.FirstName)
                .NotNull()
                .Length(3, 30)
                .WithMessage("Неправильная имя");

            RuleFor(h => h.LastName)
                .NotNull()
                .Length(3,30)
                .WithMessage("Неправильная фамилия");

            RuleFor(f => f.Age)
                .NotNull()
                .WithMessage("Укажите возраст + 18")
                .GreaterThan(17)
                .LessThan(65);

            RuleFor(f => f.PhoneNumber)
                .Matches(regex);

            RuleFor(f => f.PassportNumber)
                .Must(t => t.Length == 9)
                .WithMessage("Номер паспорт состоит из 9 цифров");
        }
    }
}
