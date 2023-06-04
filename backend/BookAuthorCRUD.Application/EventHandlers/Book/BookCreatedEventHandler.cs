using BookAuthorCRUD.Domain.Events.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BookAuthorCRUD.Application.EventHandlers.Book
{
    internal class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
    {

        private readonly ILogger<BookCreatedEventHandler> _logger;
        public BookCreatedEventHandler(ILogger<BookCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[BookAuthorCRUD] ~ Book created with Id: {@Id}",notification.Entity.Id);
            return Task.CompletedTask;
        }
    }
}
