using System.Runtime;
using AutoMapper;
using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Movie, MovieRequestModel>().ReverseMap();
            CreateMap<Movie, MovieResponseModel>().ReverseMap();
            CreateMap<Actor, ActorRequestModel>().ReverseMap();
            CreateMap<Actor,ActorResponseModel>().ReverseMap();
            CreateMap<Producer,ProducerRequestModel>().ReverseMap();
            CreateMap<Producer, ProducerResponseModel>().ReverseMap();
            CreateMap<Review,ReviewRequestModel>().ReverseMap();
            CreateMap<Review,ReviewResponseModel>().ReverseMap();
            CreateMap<Genre,GenreResponseModel>().ReverseMap();
            CreateMap<Genre,GenreRequestModel>().ReverseMap();
        }
    }
}
