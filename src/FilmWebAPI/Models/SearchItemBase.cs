using System;
using System.ComponentModel;

namespace FilmWebAPI.Requests.Get.SearchImpl
{
    public class SearchItemBase
    {
        internal ItemType ItemType { get; }
        internal string[] Raw { get; }

        public SearchItemBase(ItemType itemType, string[] raw)
        {
            if (!Enum.IsDefined(typeof(ItemType), itemType))
            {
                throw new InvalidEnumArgumentException(nameof(itemType), (int)itemType, typeof(ItemType));
            }

            ItemType = itemType;
            Raw = raw ?? throw new ArgumentNullException(nameof(raw));
        }
    }
}