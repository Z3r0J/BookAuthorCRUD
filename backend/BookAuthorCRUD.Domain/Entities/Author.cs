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
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; private set; } = DateTime.UtcNow;
        public ICollection<Book> Books { get; private set; } = new List<Book>();

        public Author() { }

        public Author(string firstName, string lastName, string address, string email, DateTime birthDate, ICollection<Book>? books)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            BirthDate = birthDate;
            Books = books ?? new List<Book>();
        }



    }
}
