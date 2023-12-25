namespace Reflections
{
    public class Book
    {
        [ReportItem(2)]
        public string Author { get; set; }
        [ReportItem(1)]
        public string Title { get; set; }
        [ReportItem(3, Heading = "Date of Publish", Format ="dd-MM-yyyy")]
        public DateTime DateOfPublish { get; set; }
        [ReportItem(4)]
        public Rating Rating { get; set; }
    }

    public static class BookData
    {
        public static IEnumerable<Book> Books()
            => new List<Book>()
            {
                new Book
                {
                    Author = "Ian Flemming", Title="Goldfinger", DateOfPublish = new DateTime(1982,5,23), Rating=Rating.Average 
                },
                new Book
                {
                    Author = "Ian Flemming", Title="Dr. No", DateOfPublish = new DateTime(1958,2,14), Rating=Rating.Excellent
                },
                new Book
                {
                    Author = "Rebecca Yarros", Title="Iron Flame", DateOfPublish = new DateTime(2023,11,07), Rating=Rating.Good
                },
                new Book
                {
                    Author = "Ayn Rand", Title="Atlas Shrugged", DateOfPublish = new DateTime(1957,10,10), Rating=Rating.Bad
                },
                 new Book
                {
                    Author = "Joseph Heller", Title="Catch-22", DateOfPublish = new DateTime(1961,11,10), Rating=Rating.Excellent
                },
                new Book
                {
                    Author = "Margaret Mitchell", Title="Gone with the Wind", DateOfPublish = new DateTime(1936,6,30), Rating=Rating.Average
                }
            };
    }
}
