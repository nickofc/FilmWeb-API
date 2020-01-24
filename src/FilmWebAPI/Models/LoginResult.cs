namespace FilmWebAPI.Models
{
    public class LoginResult
    {
        public bool IsLoggedIn { get; }

        public User User { get; }

        public LoginResult(bool isLoggedIn, User user)
        {
            IsLoggedIn = isLoggedIn;
            User = user;
        }
    }
}
