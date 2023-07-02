using System;
using FluentValidation;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    public class CreateMailCommandValidator : AbstractValidator<CreateMailCommand>
    {
        public CreateMailCommandValidator()
        {
            RuleFor(mail=>mail.Body).MaximumLength(384000);
            RuleFor(mail => mail.Subject).MaximumLength(1000);
        }
    }
}
