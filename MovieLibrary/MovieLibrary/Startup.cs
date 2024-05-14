using MovieLibrary.Repositories;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.Services.Interfaces;
using MovieLibrary.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieLibrary
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.Configure<ConnectionString>(configuration.GetSection("ConnectionString"));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}