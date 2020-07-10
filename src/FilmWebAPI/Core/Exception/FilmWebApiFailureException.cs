namespace FilmWebAPI.Core.Exception
{
    using System;

    public class FilmWebApiFailureException : FilmWebException
    {
        public FilmWebApiFailureException(string message) : base(message)
        {
        }

        public FilmWebApiFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
