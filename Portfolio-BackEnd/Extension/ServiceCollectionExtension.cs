using System.Reflection;
using System.Text;
using Data;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Language.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portfolio_BackEnd.Filters;
using Services.Abstract;
using Services.Implementations;

namespace Portfolio_BackEnd.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            }
            else if (environment.IsProduction())
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_URL")));

                using (var context = new DataContext(new DbContextOptionsBuilder<DataContext>()
                           .UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_URL")).Options))
                {
                    context.Database.Migrate();
                }
            }

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScopedServiceTypes(typeof(TokenService).Assembly, typeof(IService));

            if (environment.IsDevelopment())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("*");
                    });
                });
            }
            else if (environment.IsProduction())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("https://hristo.ch", "http://localhost:5173/")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("*");
                    });
                });
            }

            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(LanguageProfile));

            return services;
        }

        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = true;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET") ??
                                                configuration["JWT:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddAuthorization();
            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio-BackEnd", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static IServiceCollection RegisterFilters(this IServiceCollection services)
        {
            services.AddControllers(options => { options.Filters.Add<CustomExceptionFilter>(); });

            return services;
        }

        private static IServiceCollection AddScopedServiceTypes(this IServiceCollection services, Assembly assembly,
            Type fromType)
        {
            var serviceTypes = assembly.GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.Namespace) && x.IsClass && !x.IsAbstract &&
                            fromType.IsAssignableFrom(x))
                .Select(x => new
                {
                    Interface = x.GetInterface($"I{x.Name}"),
                    Implementation = x
                });
            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType.Interface, serviceType.Implementation);
            }

            return services;
        }
    }
}