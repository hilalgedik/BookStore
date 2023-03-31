using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().Length(2, 25);
            RuleFor(command => command.Model.Surname).NotEmpty().Length(2, 25);
            RuleFor(command => command.Model.Birthday).LessThan(DateTime.Now.AddYears(-18)).WithMessage("18 yaşindan küçükler için kayit yapilamaz.");
        }
    }
}