namespace StockExchange
{
    using Microsoft.EntityFrameworkCore;
    using StockExchange.DAL.DataModel; //can i make a reference like this? 

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ///DbContext is injected here. References appsettings.json
            ///
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlite($"Data Source=../Database/StockExchangeDb"
            ));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}