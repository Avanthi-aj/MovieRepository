using MovieLibrary.Entities;

namespace MovieLibrary.RequestModel
{
    public class MovieRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<int> Actors { get; set; }
        public List<int> Genres { get; set; }
        public int Producer { get; set; }
        public String CoverImage { get; set; }
    }
}
