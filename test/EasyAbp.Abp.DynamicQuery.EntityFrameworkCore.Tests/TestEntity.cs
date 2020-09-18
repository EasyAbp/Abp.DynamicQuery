namespace EasyAbp.Abp.DynamicQuery
{
    public class Book
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public BookType Type { get; set; }
    }

    public enum BookType
    {
        Adventure,
        Biography,
        Dystopia,
    }
}