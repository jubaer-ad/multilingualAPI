
using Microsoft.EntityFrameworkCore;
using MLIMS.Data;
using MLIMS.Helper;
using MLIMS.DI;

namespace MLIMS
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
            builder.Services.AddDbContext<MLIMSDbContext>(options =>
                options.UseInMemoryDatabase("MLIMSDb")
            );

            builder.Services.LoadDependencies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            using var scope = app.Services.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<MLIMSDbContext>();
            ctx.Database.EnsureCreated();
            DbSeeder.Seed(ctx);


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
