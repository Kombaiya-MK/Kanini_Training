using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAppPubs.Interfaces;
using WebAppPubs.Models;
using WebAppPubs.Services;

namespace WebAppPubs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<pubsContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));
            builder.Services.AddScoped<IAuthor<Author>, AuthorRepo>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<IPublishers<Publisher>, PublisherRepo>();
            builder.Services.AddScoped<PublisherService>();
            builder.Services.AddScoped<ITokenGenerate, TokenService>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseAuthentication();    


            app.MapControllers();

            app.Run();
        }
    }
}