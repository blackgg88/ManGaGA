using ManGAGA_BAL.Services;
using ManGAGA_DAL.Data;
using ManGAGA_DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplicationAPI_BAL.Services;

namespace ManGAGA.UI
{
    public class Startup
    {
        public IConfiguration Config { get; }
        public Startup(IConfiguration config)
        {
            Config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddScoped<ITokenService, TokenService>();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddDbContext<AppDbContext>();
            services.AddSwaggerGen();
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };
            });

            //-------------------------- Mangas --------------------------
            services.AddScoped<IMangaRepository, MangaRepository>();
            services.AddScoped<IMangaService, MangaService>();

            //-------------------------- Genders --------------------------
            services.AddScoped<IGendersRepository, GendersRepository>();
            services.AddScoped<IGendersService, GendersService>();

            //-------------------------- Chapers --------------------------
            services.AddScoped<IChaperRepository, ChaperRepository>();
            services.AddScoped<IChaperService, ChaperService>();

            //-------------------------- Pages --------------------------
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPageService, PageService>();

            //-------------------------- Photos --------------------------
            services.AddScoped<IPhotoService, PhotoService>();

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://Localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles();
        }
    }
}
