using System;
using System.Linq;
using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Security;

namespace FilmWebAPI.Core.Communication
{
    public sealed class Signature : ISignature
    {
        private const string ApiKey = "qjcGhW2JnvGT9dfCt3uT_jozR3s";

        private Signature(string method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method), "Nazwa metody nie może być pusta!");
        }

        private readonly string _method;
        private string _signature;

        public string GetMethod()
        {
            return _method;
        }

        public string GetSignature()
        {
            return _signature ?? (_signature = ComputeSign());
        }

        private string ComputeSign()
        {
            const string version = "android";
            return $"1.0,{Md5.ComputeHash($"{_method}{version}{ApiKey}")}";
        }

        public static Signature Create(string method, params object[] arguments)
        {
            return arguments != null && arguments.Any() ? new Signature(GetMethod(method, arguments)) : new Signature(method);
        }

        private static string GetMethod(string method, params object[] arguments)
        {
            return $"{method} [{string.Join(", ", arguments)}]\n";
        }
    }
}