﻿using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Author.Command.Update;

public record UpdateAuthorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    DateTime BirthDate
) : IRequest<Result<bool>>;
