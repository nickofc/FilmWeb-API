using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI
{
    public class FilmWebException : Exception
    {
        public readonly FilmWebExceptionType ExceptionType;

        public FilmWebException()
        {
        }

        public FilmWebException(string message) : base(message)
        {
        }

        public FilmWebException(FilmWebExceptionType exceptionType)
        {
            ExceptionType = exceptionType;
        }

        public FilmWebException(string message, FilmWebExceptionType exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public FilmWebException(string message, Exception innerException, FilmWebExceptionType exceptionType) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }
    }


    public enum FilmWebExceptionType
    {
        UserNotLoggedIn,
        IncorrectCredentials,
        HttpMethodNotSupported,
        UnableToGetData,
    }
}