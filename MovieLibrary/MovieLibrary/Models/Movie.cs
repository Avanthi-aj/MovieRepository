namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int Producer { get; set; }
        public string CoverImage { get; set; }
    }
}
