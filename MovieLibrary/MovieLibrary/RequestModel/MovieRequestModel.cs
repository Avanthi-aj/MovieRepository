namespace MovieLibrary.RequestModel
{
    public class MovieRequestModel
    {
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int Producer { get; set; }
        public List<int> Actors { get; set; }
        public List<int> Genres { get; set; }
        public string CoverImage { get; set; }
    }
}
