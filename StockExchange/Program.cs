namespace StockExchange
{
    using Microsoft.EntityFrameworkCore;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.BLL.Infrastructure.Services;
    using StockExchange.DAL.DataModel; // can i make a reference like this?
    using StockExchange.DAL.Repos;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model.Mapping;

    /// <summary>
    /// main class for WebService.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry-point in Application.
        /// </summary>
        /// <param name="args">Array of Arguments for Startup.</param>
        /// <returns>An integer representing the success of the Application.</returns>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DbContext is injected here. References appsettings.json
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("StockExchangeDb")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.RegisterType<>().As<BaseRepo>(); //i tried to replicate the DI of OTD
            //builder.Services.AddScoped<IBaseRepo, BaseRepo>(); //should i scope the base classes?
            builder.Services.AddScoped<IExchangeRepo, ExchangeRepo>();
            builder.Services.AddScoped<IStockSymbolsRepo, StockSymbolsRepo>();
            builder.Services.AddScoped<IEodPriceRepo, EodPriceRepo>();
            builder.Services.AddScoped<IExchangeService, ExchangeService>();
            builder.Services.AddScoped<IStockSymbolService, StockSymbolService>();
            builder.Services.AddScoped<IEodPriceService, EodPriceService>();
            //mapping
            builder.Services.AddAutoMapper(typeof(MappingProfiles));

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
