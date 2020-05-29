namespace FilmWebAPI.Requests.Get
{
    public class Item
    {
        public ItemType ItemType { get; }
        public string[] Raw { get; }
        public Item(ItemType itemType, string[] raw)
        {
            ItemType = itemType;
            Raw = raw;
        }

        public ItemPerson ToPerson()
        {
            return new ItemPerson(this);
        }

        public ItemMovie ToMovie()
        {
            return new ItemMovie(this);
        }

        public ItemSerial ToSerial()
        {
            return new ItemSerial(this);
        }
    }
}