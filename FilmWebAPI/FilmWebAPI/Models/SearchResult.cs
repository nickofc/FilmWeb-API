namespace FilmWebAPI.Models
{
    public class SearchResult
    {
        public string ImagePath { get; internal set; }

        public string Info { get; internal set; }

        public long LinkedEntityId { get; internal set; }

        public string Name { get; internal set; }

        public int OrderOnList { get; internal set; }

        public string SecondInfo { get; internal set; }

        public int Type { get; internal set; }

        public string UrlPrefix { get; internal set; }

        public static int GetOrderOnList(int type)
        {
            switch (type)
            {
                case 0:
                case 1:
                    return 3;

                case 2:
                    return 2;

                case 3:
                    return 0;

                case 4:
                    return 1;

                default:
                    return 0;
            }
        }

        public SearchResult(int type)
        {
            Type = type;
            OrderOnList = GetOrderOnList(type);
        }
    }

    public enum Type
    {
        Movie,
        Person,
        Cinema,
        NonLiveUserFriends,
        NonLiveTvChanne
    }
}