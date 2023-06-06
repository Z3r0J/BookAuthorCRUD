using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Events.Author
{
    public class AuthorCreatedEvent : BaseEvent<Entities.Author>
    {
        public AuthorCreatedEvent(Entities.Author entity)
            : base(entity) { }
    }
}
