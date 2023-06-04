using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Events.Genre
{
    public class GenreDeletedEvent : BaseEvent<Entities.Genre>
    {
        public GenreDeletedEvent(Entities.Genre entity)
            : base(entity) { }

    }
}
