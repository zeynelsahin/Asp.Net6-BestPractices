using BestPractices.Api.Models;
using FluentValidation;

namespace BestPractices.Api.Validation;

public class ContactValidator: AbstractValidator<ContactDVO>
{
    public ContactValidator()
    {
        RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100 den büyük olamaz");
        RuleFor(x => x.FullName).NotEmpty();

    }
}