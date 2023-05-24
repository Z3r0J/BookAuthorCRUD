using BookAuthorCRUD.Contract.DTOs.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.Validations.Author
{
    public class AuthorRequestValidation : AbstractValidator<AuthorRequest>
    {
        public AuthorRequestValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Date of birth is required")
                .LessThan(DateTime.Now)
                .WithMessage("Date of birth cannot be greater than today");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MinimumLength(10)
                .WithMessage("Address must be at least 10 characters long");
        }
    }
}
