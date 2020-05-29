using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Communication
{
    public abstract class RequestBase<TEntity> : IRequest<TEntity>
    {
        private readonly ISignature _signature;
        private readonly FilmWebHttpMethod _filmWebHttpMethod;

        protected RequestBase() { }

        protected RequestBase(ISignature signature, FilmWebHttpMethod filmWebHttpMethod)
        {
            _signature = signature ?? throw new ArgumentNullException(nameof(signature));
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
                    return new HttpRequestMessage(HttpMethod.Get, Url.Create(FilmWebApi.API_URL, args));
                case FilmWebHttpMethod.Post:
                    return new HttpRequestMessage(HttpMethod.Post, FilmWebApi.API_URL)
                    {
                        Content = new FormUrlEncodedContent(args)
                    };
                default:
                    throw new NotImplementedException($"The {_filmWebHttpMethod} method is not supported!");
            }
        }

        public abstract Task<TEntity> Parse(HttpResponseMessage responseMessage);

        protected async Task<TJsonEntity> GetJsonBody<TJsonEntity>(HttpResponseMessage responseMessage)
        {
            if (responseMessage is null)
            {
                throw new ArgumentNullException(nameof(responseMessage));
            }

            var raw = await GetRawBody(responseMessage);
            return ParseJson<TJsonEntity>(raw);
        }
        protected async Task<string> GetRawBody(HttpResponseMessage responseMessage)
        {
            if (responseMessage is null)
            {
                throw new ArgumentNullException(nameof(responseMessage));
            }

            var content = await responseMessage.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            if (content.StartsWith("err"))
            {
                throw new FilmWebApiFailureException("FilmWebAPI returned an problem.");
            }

            if (content.StartsWith("ok"))
            {
                content = content.Remove(0, 3);
                var endJsonBraceIndex = content.LastIndexOf("]",
                    StringComparison.OrdinalIgnoreCase);

                if (endJsonBraceIndex > 0)
                {
                    content = content.Substring(0,
                        endJsonBraceIndex + 1);
                }

                content = content.Trim();
            }

            if (content.StartsWith("exc"))
            {
                throw new FilmWebInternalException("FilmWebAPI returned an internal exception. \n" +
                                                   $"{content.Substring(3, content.Length - 3)}.");
            }

            return content;
        }

        private static TJsonType ParseJson<TJsonType>(string raw)
        {
            try
            {
                return JsonConvert.DeserializeObject<TJsonType>(raw);
            }
            catch (JsonException exception)
            {
                throw new FilmWebApiFailureException("FilmWebAPI returned an invalid json format.", exception);
            }
        }
    }
}