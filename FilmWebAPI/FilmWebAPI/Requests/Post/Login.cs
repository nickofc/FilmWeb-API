using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using Newtonsoft.Json;

namespace FilmWebAPI.Requests.Post
{
    public class Login : RequestBase<User>
    {
        public Login(string username, string password) : base(Signature.Create("login", username, password, "1"), FilmWebHttpMethod.Post)
        {
        }

        public override async Task<User> Parse(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.StartsWith("ok"))
            {
                var json = JsonConvert.DeserializeObject<dynamic>(content.Remove(0, 3));
                return new User
                {
                    Nick = json[0],
                    Name = json[2],
                    Id = json[3],
                    Sex = json[4].ToString().Equals("M") ? Sex.Male : Sex.Female,
                    Birthday = json[5],
                };
            }
            throw new FilmWebException(FilmWebExceptionType.IncorrectCredentials);
        }
    }
}