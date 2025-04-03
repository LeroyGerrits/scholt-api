using Scalar.AspNetCore;
using Scholt.Api.Data;
using Scholt.Api.Data.Interfaces;
using Scholt.Api.Repositories;
using Scholt.Api.Repositories.Interfaces;

namespace Scholt.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IScholtApiContext, ScholtApiContext>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}