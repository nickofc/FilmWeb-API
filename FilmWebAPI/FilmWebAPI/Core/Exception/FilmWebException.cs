using System;

namespace FilmWebAPI
{
    public class FilmWebException : Exception
    {
        public readonly FilmWebExceptionType FilmWebExceptionType;

        public FilmWebException(FilmWebExceptionType exceptionType)
        {
            FilmWebExceptionType = exceptionType;
        }

        public FilmWebException(string message, FilmWebExceptionType filmWebExceptionType) : base(message)
        {
            FilmWebExceptionType = filmWebExceptionType;
        }
    }
}