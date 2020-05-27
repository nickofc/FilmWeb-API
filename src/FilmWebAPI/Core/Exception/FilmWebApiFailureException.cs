namespace FilmWebAPI.Core.Exception
{
    public class FilmWebApiFailureException : FilmWebException
    {
        public FilmWebApiFailureException(string message) : base(message)
        {
        }

        public FilmWebApiFailureException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
