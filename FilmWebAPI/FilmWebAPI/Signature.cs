using System;
using System.Linq;
using FilmWebAPI.Helpers;

namespace FilmWebAPI
{
    /// <summary>
    /// Klasa do podpisywania zapytań API
    /// </summary>
    public sealed class Signature
    {
        private readonly string _method;
        private string _signature;

        public Signature(string method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method), "Nazwa metody nie może być pusta!");
        }

        public string GetMethod()
        {
            return _method;
        }

        public string GetSignature()
        {
            if (_signature == null)
                return _signature = HashHelpers.MakeSignature(_method);

            return _signature;
        }

        public static Signature Create(string method, params string[] strings)
        {
            if (strings != null && strings.Any())
            {
                return new Signature(HashHelpers.ToCSV(method, strings));
            }
            return new Signature(method);
        }
    }
}