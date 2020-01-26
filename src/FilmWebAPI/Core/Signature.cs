using FilmWebAPI.Helpers;
using FilmWebAPI.Security;
using System;
using System.Linq;

namespace FilmWebAPI
{
    /// <summary>
    /// Klasa do podpisywania zapytań API
    /// </summary>
    public sealed class Signature : ISignature
    {
        const string API_KEY = "qjcGhW2JnvGT9dfCt3uT_jozR3s";

        private readonly string _method;
        private string _signature;

        private Signature(string method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method), "Nazwa metody nie może być pusta!");
        }

        public string GetMethod()
        {
            return _method;
        }

        public string GetSignature()
        {
            return _signature ?? (_signature = ComputeSign());
        }

        public static Signature Create(string method, params object[] arguments)
        {
            return arguments != null && arguments.Any() ? new Signature(ToCSV(method, arguments)) : new Signature(method);
        }

        private string ComputeSign()
        {
            const string version = "android";
            return $"1.0,{Md5.ComputeHash($"{_method}{version}{API_KEY}")}";
        }

        internal static string ToCSV(string method, params object[] arguments)
        {
            return $"{method} [{Csv.To(arguments)}]\n";
        }
    }
}