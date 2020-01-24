namespace FilmWebAPI
{
    public interface ISignature
    {
        string GetMethod();

        string GetSignature();
    }
}