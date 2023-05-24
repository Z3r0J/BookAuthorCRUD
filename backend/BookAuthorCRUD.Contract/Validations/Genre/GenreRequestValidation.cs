using BookAuthorCRUD.Contract.DTOs.Genre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.Validations.Genre;

public class GenreRequestValidation : AbstractValidator<GenreRequest>
{
    public GenreRequestValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Genre name is required");
        RuleFor(x => x.Name)
            .MinimumLength(1)
            .MaximumLength(100)
            .WithMessage("Genre name must be between 1 and 100 characters long");
    }
}
