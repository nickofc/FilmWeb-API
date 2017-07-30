using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Models
{
    public class SearchResult
    {
        public string ImagePath { get; set; }
        public string Info { get; set; }
        public long LinkedEntityId { get; set; }
        public String Name { get; set; }
        public int OrderOnList { get; set; }
        public String SecondInfo { get; set; }
        public int Type { get; set; }
        public String UrlPrefix { get; set; }


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
            this.Type = type;
            this.OrderOnList = GetOrderOnList(type);
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
