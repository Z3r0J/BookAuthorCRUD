using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Events.Genre
{
    public class GenreCreatedEvent : BaseEvent<Entities.Genre>
    {
        public GenreCreatedEvent(Entities.Genre entity)
            : base(entity) { }

    }
}
