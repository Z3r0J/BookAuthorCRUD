using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Events.Author
{
    public class AuthorDeletedEvent : BaseEvent<Entities.Author>
    {
        public AuthorDeletedEvent(Entities.Author entity)
            : base(entity) { }
    }
}
