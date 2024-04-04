using MovieLibrary.Repositories;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.Services;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<IActorRepository, ActorRepository>();
            services.AddSingleton<IProducerRepository, ProducerRepository>();
            services.AddSingleton<IGenreRepository, GenreRepository>();
            services.AddSingleton<IReviewRepository, ReviewRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IProducerService,ProducerService>();
            services.AddTransient<IReviewService,ReviewService>();
            services.AddTransient<IGenreService,GenreService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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