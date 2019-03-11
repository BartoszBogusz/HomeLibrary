namespace HomeLibrary.Models
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int Year { get; set; }
    }
}