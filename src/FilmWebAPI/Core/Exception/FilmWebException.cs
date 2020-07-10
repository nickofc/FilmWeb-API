namespace FilmWebAPI.Core.Exception
{
    using System;

    public class FilmWebException : Exception
    {
        public FilmWebException(string message) : base(message)
        {
        }

        public FilmWebException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}