
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Infra.EFRepository.Repository;
using ComicStore.Service.Interfaces;
using ComicStore.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComicStoreWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            _ = services.AddDbContext<ComicStoreDbContext>(options =>
            {
                options.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=ComicStore;Integrated Security=True");
            });

            services.AddCors(c => c.AddPolicy("ComicStorePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddScoped<IFactoryRepository, FactoryEFCoreRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IGenreService, GenreService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("ComicStorePolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
