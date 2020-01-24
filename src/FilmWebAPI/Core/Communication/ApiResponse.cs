using Newtonsoft.Json;
using System;

namespace FilmWebAPI
{
    public class ApiResponse
    {
        public bool IsSucceed { get; }

        public string Content { get; }

        public ApiResponse(bool isSucceed, string content)
        {
            IsSucceed = isSucceed;
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public static ApiResponse Failure()
        {
            return new ApiResponse(false, string.Empty);
        }

        public static ApiResponse Succeed(string content)
        {
            return new ApiResponse(true, content);
        }

        public T ToJson<T>()
        {
            return JsonConvert.DeserializeObject<T>(Content);
        }
    }
}