using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public sealed class Genre : AuditableBaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Book> Books { get; private set; } = new List<Book>();

        public Genre() { }

        public Genre(string name, ICollection<Book>? books)
        {
            Name = name;
            Books = books ?? new List<Book>();
        }


    }
}
