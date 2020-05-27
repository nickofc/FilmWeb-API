namespace FilmWebAPI.Core.Exception
{
    public class FilmWebParseException : FilmWebException
    {
        public FilmWebParseException(string message) : base(message)
        {
        }

        public FilmWebParseException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}