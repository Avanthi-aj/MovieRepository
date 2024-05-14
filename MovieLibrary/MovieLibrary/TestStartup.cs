using MovieLibrary.Services.Interfaces;
using MovieLibrary.Services;

namespace MovieLibrary
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}