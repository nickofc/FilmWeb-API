using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public abstract class RequestBase<T> : IRequest<T>
    {
        private readonly Signature _signature;
        private readonly FilmWebHttpMethod _filmWebHttpMethod;

        protected RequestBase() { }

        protected RequestBase(Signature signature, FilmWebHttpMethod filmWebHttpMethod)
        {
            _signature = signature ?? throw new System.ArgumentNullException(nameof(signature));
            _filmWebHttpMethod = filmWebHttpMethod;
        }

        public enum FilmWebHttpMethod
        {
            Get,
            Post,
        }

        public virtual HttpRequestMessage GetRequestMessage()
        {
            var args = new Dictionary<string, string>
            {
                {"methods", _signature.GetMethod()},
                {"appId", "android"},
                {"version", "2.8"},
                {"signature", _signature.GetSignature()},
            };

            switch (_filmWebHttpMethod)
            {
                case FilmWebHttpMethod.Get:
                    return new HttpRequestMessage(HttpMethod.Get, Url.Create(FilmWeb.API_URL, args));

                case FilmWebHttpMethod.Post:
                    return new HttpRequestMessage(HttpMethod.Post, FilmWeb.API_URL)
                    {
                        Content = new FormUrlEncodedContent(args)
                    };

                default:
                    throw new FilmWebException("Ta metoda nie jest obsługiwana!", FilmWebExceptionType.HttpMethodNotSupported);
            }
        }

        public abstract Task<T> Parse(HttpResponseMessage responseMessage);

        protected async Task<string> GetJsonBody(HttpResponseMessage responseMessage)
        {
            if (responseMessage is null)
            {
                throw new System.ArgumentNullException(nameof(responseMessage));
            }

            var content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!content.StartsWith("ok"))
            {
                throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
            }

            return content[3..];
        }

        protected async Task<ApiResponse> GetAsApiResponseAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage is null)
            {
                throw new System.ArgumentNullException(nameof(responseMessage));
            }

            var content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (content.StartsWith("err"))
            {
                return ApiResponse.Failure();
            }

            return ApiResponse.Succeed(content[3..]);
        }
    }
}