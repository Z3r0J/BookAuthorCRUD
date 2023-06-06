using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Events.Book
{
    public class BookDeletedEvent : BaseEvent<Entities.Book>
    {
        public BookDeletedEvent(Entities.Book entity)
            : base(entity) { }
    }
}
