using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
            RuleFor(command => command.Model.Surname).MinimumLength(4).When(x => x.Model.Surname.Trim() != string.Empty);
            RuleFor(command => command.Model.Birthday).LessThan(DateTime.Now.AddYears(-18)).WithMessage("18 yaşindan küçükler için kayit yapilamaz.");

        }

    }
}