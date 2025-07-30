namespace BookstoreApi.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
