﻿using FilmWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetAllChannels : RequestBase<IReadOnlyCollection<Channel>>
    {
        public GetAllChannels() : base(Signature.Create("getAllChannels", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Channel>> Parse(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.StartsWith("ok"))
            {
                var jsonBody = content.Remove(0, 3);
                var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

                return json.Skip(1).Select(token =>
                {
                    var array = token as JArray;
                    if (array == null) return null;

                    return new Channel
                    {
                        Id = array[0].ToObject<int>(),
                        Name = array[1].ToObject<string>(),
                        ImagePath = array[2].ToObject<string>(),
                        DayStartHour = array[3].ToObject<int>(),
                    };
                }).ToArray();
            }
            throw new FilmWebException(content, FilmWebExceptionType.UnableToGetData);
        }
    }
}