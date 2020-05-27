using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Core.Exception
{
    public class FilmWebInternalException : FilmWebException
    {
        public FilmWebInternalException(string message) : base(message)
        {
        }

        public FilmWebInternalException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
