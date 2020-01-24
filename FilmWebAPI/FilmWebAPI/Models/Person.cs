namespace FilmWebAPI.Models
{
    public class Person
    {
        public ulong PersonId { get; }
        public string PersonName { get; }
        public string KnownAs { get; }

        public Person(ulong personId, string personName, string knownAs)
        {
            PersonId = personId;
            PersonName = personName;
            KnownAs = knownAs;
        }
    }
}
