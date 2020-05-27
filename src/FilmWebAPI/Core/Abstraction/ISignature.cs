namespace FilmWebAPI.Core.Abstraction
{
    public interface ISignature
    {
        string GetMethod();

        string GetSignature();
    }
}