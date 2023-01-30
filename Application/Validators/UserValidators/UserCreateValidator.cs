using Domain.Entities.Common;
using FluentValidation;
using Hr.Application.Models.UserModels;
using System.Text.RegularExpressions;

namespace Hr.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateValidator()
        {
            var regex = new Regex(@"((992){1}\d{9}|(7){1}\d{10}){1}");

            RuleFor(r => r.FirstName)
                .NotNull()
                .WithMessage("Заполните имя пользователя")
                .Length(3,30);            
            
            RuleFor(r => r.LastName)
                .NotNull()
                .WithMessage("Заполните фамилию пользователя")
                .Length(3, 30);

            RuleFor(r => r.Age)
                .NotNull()
                .WithMessage("Укажите возраст (+18)")
                .GreaterThan(17)
                .LessThan(65);

            RuleFor(r => r.PhoneNumber)
                .Matches(regex);

            RuleFor(x => x.PassportNumber)
                .Must(t => t.Length == 9)
                .WithMessage("Номер паспорт состоит из 9 цифров");
        }
    }
}
