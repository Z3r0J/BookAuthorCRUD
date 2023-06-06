using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Exception
{
    public class ExceptionResult
    {
        public string Message { get; set; }
        public string ErrorId { get; set; }

        public string Source { get; set; }
        public string SupportMessage { get; set; }
        public int StatusCode { get; set; }

    }
}
