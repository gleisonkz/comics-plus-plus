
using ComicStore.Application.Classes;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Infra.EFRepository.Context;
using ComicStore.Infra.EFRepository.Repository;
using ComicStore.Service.Interfaces;
using ComicStore.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;

namespace ComicStoreWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson();

            _ = services.AddDbContext<ComicStoreDbContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionStrings:IdentityConnection"].ToString())
                           .EnableSensitiveDataLogging()
                           .UseLazyLoadingProxies();

                });

            _ = services.AddDbContext<ComicStoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:IdentityConnection"].ToString());
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Comic Store",
                    Version = "v1",
                    Description = "Sample service for Learner",
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                    new string[] { }
                }
                });
            });


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
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();



            services.AddScoped<AuthenticationHelper>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ComicStoreIdentityDbContext>()
                    .AddDefaultTokenProviders();



            var key = Encoding.ASCII.GetBytes(configuration["ApplicationSettings:JWT_Secret"].ToString());

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

            /* UserCors EVER must to be placed after UserRouting 
              and before UseAuthentication and UseAuthorization
            */
            app.UseCors("ComicStorePolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comic Store API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
