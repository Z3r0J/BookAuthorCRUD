using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Update;

public record UpdateGenreCommand(Guid Id, Guid Name) : IRequest<Result<bool>>;
