namespace HomeLibrary.Models
{
    public class EditBookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int Year { get; set; }
    }
}
