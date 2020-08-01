using System;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Post
{
    public class Login : JsonRequestBase<User, string[]>
    {
        public Login(string username, string password) : base(Signature.Create("login", username, password, "1"), FilmWebHttpMethod.Post)
        {
        }

        public override Task<User> Parse(string[] entity)
        {

            
            return new Task<User>(null);

            // var user = new User
            // {
            //     Nick = json[0],
            //     Name = json[2],
            //     Id = json[3],
            //     Sex = json[4].ToString().Equals("M") ? Sex.Male : Sex.Female,
            //     Birthday = json[5],
            // };
            //
            // return new LoginResult(true, user);
        }
    }

    public class User
    {
        public UserId Id { get; internal set; }
        public string Username { get; internal set; }
        public string Name { get; internal set; }
        public Sex Sex { get; internal set; }
        public DateTime Birthday { get; internal set; }
    }

    public enum Sex
    {
        Unknown,
        Male,
        Female
    }

    public class UserId
    {

    }
}