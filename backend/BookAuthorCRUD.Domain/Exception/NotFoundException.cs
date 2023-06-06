using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message, object key)
            : base($"{message} with entity {key}")
        {
        }

        public int StatusCode { get; set; } = 404;

    }
}
