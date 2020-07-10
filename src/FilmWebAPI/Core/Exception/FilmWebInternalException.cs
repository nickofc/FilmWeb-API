namespace FilmWebAPI.Core.Exception
{
    public class FilmWebInternalException : FilmWebException
    {
        public FilmWebInternalException(string message) : base(message)
        {
        }
    }
}
