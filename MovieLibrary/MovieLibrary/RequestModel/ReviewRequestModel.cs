namespace MovieLibrary.RequestModel
{
    public class ReviewRequestModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int MovieId { get; set; }
    }
}
