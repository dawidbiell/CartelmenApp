using FluentValidation;

namespace Cartelmen.Application.CQRS.Person.Commands;
public class PersonCreateCommandValidator :AbstractValidator<PersonCreateCommand>
{
    public PersonCreateCommandValidator()
    {
        RuleFor(w => w.FirstName)
            .NotEmpty();
            //.WithMessage("{PropertyName} can not be empty");

            RuleFor(w => w.LastName);
            //.NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(w => w.Email)
                .EmailAddress().When(w => !string.IsNullOrEmpty(w.Email));
            //.WithMessage("{PropertyName} has to be correct email address");

        RuleFor(w => w.PayRate)
            .GreaterThan(0);
    }
}
