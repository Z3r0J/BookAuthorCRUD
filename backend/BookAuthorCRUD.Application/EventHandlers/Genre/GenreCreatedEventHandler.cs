using BookAuthorCRUD.Domain.Events.Genre;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.EventHandlers.Genre
{
    internal class GenreCreatedEventHandler: INotificationHandler<GenreCreatedEvent>
    {
        private readonly ILogger<GenreCreatedEventHandler> _logger;

        public GenreCreatedEventHandler(ILogger<GenreCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(GenreCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[BookAuthorCRUD] ~ Genre created with Id: {@Id}", notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
