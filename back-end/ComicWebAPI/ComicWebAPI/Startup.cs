using Comic.Business.Interfaces;
using Comic.RepositoryEF.Class;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proffy.Repository.Interfaces;

namespace ComicWebAPI
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
            //_ = services.AddDbContext<ComicContext>(options =>
            //{
            //    options.UseSqlServer("Password=sa123456;Persist Security Info=True;User ID=sa;Initial Catalog=Proffy;Data Source=DESKTOP-2AKCSN7\\PROFFY");
            //});

            services.AddCors(c => c.AddPolicy("ComicPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));



            _ = services.AddScoped<IFactoryRepository, FactoryEFCoreRepository>();
            _ = services.AddScoped<IUnityOfWork, UnityOfWork>();

            _ = services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseCors("ComicPolicy");


            _ = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
