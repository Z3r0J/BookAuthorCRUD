using BookAuthorCRUD.Domain.Events.Author;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.EventHandlers.Author
{
    public class AuthorCreatedEventHandler : INotificationHandler<AuthorCreatedEvent>
    {

        private readonly ILogger<AuthorCreatedEventHandler> _logger;
        public AuthorCreatedEventHandler(ILogger<AuthorCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AuthorCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[BookAuthorCRUD] ~ Author created with Id: {@Id}", notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
