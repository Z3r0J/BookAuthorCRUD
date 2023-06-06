using BookAuthorCRUD.Domain.Events.Book;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.EventHandlers.Book
{
    public class BookDeletedEventHandler : INotificationHandler<BookDeletedEvent>
    {
        private readonly ILogger<BookDeletedEventHandler> _logger;

        public BookDeletedEventHandler(ILogger<BookDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning("[BookAuthorCRUD] ~ Book Deleted with Id: {@Id}", notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
