namespace FilmWebAPI.Core.Exception
{
    public class FilmWebException : System.Exception
    {
        public FilmWebException(string message) : base(message)
        {
        }

        public FilmWebException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}