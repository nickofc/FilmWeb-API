using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Helpers;

namespace FilmWebAPI
{
    public abstract class RequestBase<T> : IHttpExecutable, IRequest<T>
    {
        private readonly Signature _signature;
        private readonly FilmWebHttpMethod _filmWebHttpMethod;

        protected RequestBase()
        {
        }

        protected RequestBase(Signature signature, FilmWebHttpMethod filmWebHttpMethod)
        {
            _signature = signature;
            _filmWebHttpMethod = filmWebHttpMethod;
        }

        public enum FilmWebHttpMethod
        {
            Get,
            Post,
        }

        public virtual HttpRequestMessage GetRequestMessage()
        {
            var query = new Dictionary<string, string>
            {
                {"methods", _signature.GetMethod()},
                {"appId", "android"},
                {"version", "2.8"},
                {"signature", _signature.GetSignature()},
            };

            switch (_filmWebHttpMethod)
            {
                case FilmWebHttpMethod.Get:
                    return new HttpRequestMessage(HttpMethod.Get, QueryHelpers.CreateQuery(FilmWeb.API_URL, query));

                case FilmWebHttpMethod.Post:
                    return new HttpRequestMessage(HttpMethod.Post, FilmWeb.API_URL)
                    {
                        Content = new FormUrlEncodedContent(query)
                    };

                default:
                    throw new FilmWebException("Ta metoda nie jest obsługiwana!", FilmWebExceptionType.HttpMethodNotSupported);
            }
        }

        public abstract Task<T> Parse(HttpResponseMessage responseMessage);

        protected async Task<string> GetJsonBody(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (!content.StartsWith("ok"))
            {
                throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
            }

            return content[3..];
        }
    }
}