using BookAuthorCRUD.Domain.Events.Author;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookAuthorCRUD.Application.EventHandlers.Author
{
    internal class AuthorDeletedEventHandler : INotificationHandler<AuthorDeletedEvent>
    {
        private readonly ILogger<AuthorDeletedEventHandler> _logger;
        public AuthorDeletedEventHandler(ILogger<AuthorDeletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(AuthorDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning("[BookAuthorCRUD] ~ Author Deleted with Id: {@Id}", notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
