using System.Runtime;
using AutoMapper;
using MovieLibrary.Models;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Movie, MovieRequestModel>().ReverseMap();
            CreateMap<Movie, MovieResponseModel>()
                .ForMember(m => m.Producer, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Actor,ActorRequestModel>().ReverseMap();
            CreateMap<Actor, ActorResponseModel>().ReverseMap();
            CreateMap<Producer,ProducerResponseModel>().ReverseMap();
            CreateMap<Producer, ProducerRequestModel>().ReverseMap();
            CreateMap<Genre,GenreResponseModel>().ReverseMap();
            CreateMap<Genre, GenreRequestModel>().ReverseMap();
            CreateMap<Review,ReviewResponseModel>().ReverseMap();
            CreateMap<Review, ReviewRequestModel>().ReverseMap();
        }
    }
}
