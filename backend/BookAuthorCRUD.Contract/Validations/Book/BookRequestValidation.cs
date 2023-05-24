using BookAuthorCRUD.Contract.DTOs.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.Validations.Book
{
    public class BookRequestValidation : AbstractValidator<BookRequest>
    {
        public BookRequestValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("The Title shouldn't be empty.")
                .Length(1, 150)
                .WithMessage("The title must have 1 to 150 characters.");

            RuleFor(x => x.Sypnosis)
                .NotEmpty()
                .WithMessage("The Sypnosis shouldn't be empty.")
                .Length(1, int.MaxValue)
                .WithMessage("This should have at least 1 character.");

            RuleFor(x => x.ReleaseDate).NotNull().WithMessage("The Release Date shouldn't be null");

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .WithMessage("The Publisher shouldn't be empty.")
                .Length(1, 200)
                .WithMessage("The title must have 1 to 150 characters.");

            RuleFor(x => x.GenreId).NotEmpty().WithMessage("The GenreId is required.");

            RuleFor(x => x.AuthorsId.Count)
                .GreaterThan(0)
                .WithMessage("The book must have at least 1 author.");
        }
    }
}
