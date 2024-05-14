using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Tests.MockResources
{
    public class ActorMock
    {

        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        private static readonly List<Actor> _actorList = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "actor",
                Bio = "bio",
                DOB = DateTime.Parse("2003-03-03"),
                Gender = "Male"

            }
        };

        private static readonly Dictionary<int, List<int>> Actorsmovies = new Dictionary<int, List<int>>{
            {
                1, new List<int> { 1 }
            }
        };

        public static void MockCreate()
        {
            ActorRepoMock.Setup(x => x.Create(It.IsAny<Actor>())).Returns(1);
        }

        public static void MockUpdate()
        {
            ActorRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Actor>()));
        }

        public static void MockDelete()
        {
            ActorRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }

        public static void MockGet()
        {
            ActorRepoMock.Setup(x => x.Get()).Returns(_actorList);
        }

        public static void MockGetById()
        {
            ActorRepoMock.Setup(x => x.Get(It.Is<int>(
                Id => _actorList.FirstOrDefault(actor => actor.Id == Id) != null)))
               .Returns(_actorList.First);
        }

        public static void MockGetByMovieID()
        {
            ActorRepoMock.Setup(x => x.GetByMovie(It.IsAny<int>())).Returns((int movieId) =>
            {
                List<Actor> actors = new List<Actor>();

                if (Actorsmovies.ContainsKey(movieId))
                {
                    var actorIds = Actorsmovies[movieId];
                    actors = _actorList.Where(actor => actorIds.Contains(actor.Id)).ToList();
                }

                return actors;
            });
        }
    }
}