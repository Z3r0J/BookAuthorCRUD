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
    internal class GenreDeletedEventHandler : INotificationHandler<GenreDeletedEvent>
    {
        private readonly ILogger<GenreDeletedEventHandler> _logger;

        public GenreDeletedEventHandler(ILogger<GenreDeletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(GenreDeletedEvent notification, CancellationToken cancellationToken)
        {
          _logger.LogWarning("[BookAuthorCRUD] ~ Genre Deleted with Id: {@Id}", notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
