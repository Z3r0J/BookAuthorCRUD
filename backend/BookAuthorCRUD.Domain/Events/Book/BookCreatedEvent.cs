using BookAuthorCRUD.Domain.Common;
using BookAuthorCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Events.Book
{
    public class BookCreatedEvent : BaseEvent<Entities.Book>
    {
        public BookCreatedEvent(Entities.Book entity)
            : base(entity) { }
    }
}
