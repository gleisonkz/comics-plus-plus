
using ComicStore.Application.DTO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Infra.EFRepository.Repository;
using ComicStore.Service.Interfaces;
using ComicStore.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

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
            services.AddControllers()
                     .AddNewtonsoftJson(options =>
                      {
                          options.SerializerSettings.Converters.Add(new ComicImageConverter());
                      });

            _ = services.AddDbContext<ComicStoreDbContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"].ToString())
                           .UseLazyLoadingProxies();
                });


            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ComicStoreDbContext>()
                    .AddDefaultTokenProviders();

            services.AddCors(c => c.AddPolicy("ComicStorePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("X-Pagination");
            }));

            services.AddScoped<IFactoryRepository, FactoryEFCoreRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IComicService, ComicService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAuthorService, AuthorService>();

            var key = Encoding.ASCII.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            //Authentication With JWT
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.RequireHttpsMetadata = false;
                c.SaveToken = true;
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("ComicStore", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("ComicStore", "Admin"));
            });

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


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("ComicStorePolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
