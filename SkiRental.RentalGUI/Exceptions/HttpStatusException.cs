using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode Status { get; set; }

        public HttpStatusException(HttpStatusCode status)
        {
            Status = status;
        }

        public HttpStatusException(HttpStatusCode status, string message)
            : base(message)
        {
            Status = status;
        }

        public HttpStatusException(HttpStatusCode status, string message, Exception innerException)
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
