namespace StockExchange
{
    using Microsoft.EntityFrameworkCore;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.BLL.Infrastructure.Services;
    using StockExchange.DAL.DataModel; //can i make a reference like this? 
    using StockExchange.DAL.Repos;
    using StockExchange.DAL.Repos.Interface;

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

            //builder.Services.RegisterType<>().As<BaseRepo>(); //i tried to replicate the DI of OTD
            //builder.Services.AddScoped<IBaseRepo, BaseRepo>(); //should i scope the base classes?
            builder.Services.AddScoped<IExchangeRepo, ExchangeRepo>();
            builder.Services.AddScoped<IExchangeService, ExchangeService>();




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