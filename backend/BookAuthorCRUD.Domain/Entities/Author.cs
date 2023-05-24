using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public sealed class Author : AuditableBaseEntity
    {

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; } = DateTime.UtcNow;
        public ICollection<BookAuthor> Books { get; private set; } = new List<BookAuthor>();

        public Author() { }

        public Author(string firstName, string lastName, string address, string email, DateTime birthDate, ICollection<BookAuthor>? books)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            BirthDate = birthDate;
            Books = books ?? new List<BookAuthor>();
        }



    }
}
