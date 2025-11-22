using FluentValidation;

namespace Cartelmen.Application.CQRS.Commands.Worker;
public class WorkerCreateCommandValidator :AbstractValidator<WorkerCreateCommand>
{
    public WorkerCreateCommandValidator()
    {
        RuleFor(w => w.FirstName)
            .NotEmpty();
            //.WithMessage("{PropertyName} can not be empty");

            RuleFor(w => w.LastName);
            //.NotEmpty().WithMessage("{PropertyName} can not be empty");;

            RuleFor(w => w.Email)
                .EmailAddress().When(w => !string.IsNullOrEmpty(w.Email));
            //.WithMessage("{PropertyName} has to be correct email address");;

        RuleFor(w => w.PayRate)
            .GreaterThan(0);
            //.WithMessage("{PropertyName} has to be greater then 0");;

        //RuleFor(w => w.HiringDate)
        //    .GreaterThan(DateOnly.MinValue).When(w => w.HiringDate != null);
    }
}
