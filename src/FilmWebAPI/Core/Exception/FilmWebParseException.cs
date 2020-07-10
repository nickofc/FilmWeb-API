namespace FilmWebAPI.Core.Exception
{
    using System;

    public class FilmWebParseException : FilmWebException
    {
        public FilmWebParseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}