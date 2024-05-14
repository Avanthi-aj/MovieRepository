namespace MovieLibrary.ResponseModel
{
    public class MovieResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public ProducerResponseModel Producer { get; set; }
        public List<ActorResponseModel> Actors { get; set; }
        public List<GenreResponseModel> Genres { get; set; }
        public string CoverImage { get; set; }
    }
}
