namespace StockExchange.DAL.DataModel
{
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        ///dataseeding. On model creation i seed 3 rows in every table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exchange>().HasData(
                new Exchange
                {
                    ID = 1,
                    Name = "The New York Stock Exchange",
                    IsActive = true,
                },
                new Exchange
                {
                    ID = 2,
                    Name = "NASDAQ Stock Exchange",
                    IsActive = true,
                }, new Exchange
                {
                    ID = 3,
                    Name = "Bombay Stock Exchange",
                    IsActive = false,
                }
            );
            modelBuilder.Entity<StockSymbol>().HasData(
                new StockSymbol
                {
                    ID = 1,
                    CompanyName = "Straton Oakmount",
                    Ticker = DateTime.Now,
                    IsActive = false,
                    ExchangeId = 1
                },
                new StockSymbol
                {
                    ID = 2,
                    CompanyName = "Apple",
                    Ticker = DateTime.Now,
                    IsActive = true,
                    ExchangeId = 2

                }, new StockSymbol
                {
                    ID = 3,
                    CompanyName = "Alphabet",
                    Ticker = DateTime.Now,
                    IsActive = true,
                    ExchangeId = 3

                }
            );
            modelBuilder.Entity<EodPrice>().HasData(
                new EodPrice
                {
                    ID = 1,
                    Date = DateTime.Now,
                    ClosePrice = 10.14f,
                    StockSymbolId = 1
                },
                new EodPrice
                {
                    ID = 2,
                    Date = DateTime.Now,
                    ClosePrice = 20.14f,
                    StockSymbolId = 2

                }, new EodPrice
                {
                    ID = 3,
                    Date = DateTime.Now,
                    ClosePrice = 30.14f,
                    StockSymbolId = 3
                }
            );

        }
        /// <summary>
        /// Im using lampda Set<> to remove possible null value for the ctor
        /// </summary>
        public DbSet<Exchange> Exchanges => Set<Exchange>();
        public DbSet<StockSymbol> StockSymbols => Set<StockSymbol>();
        public DbSet<EodPrice> EodPrices => Set<EodPrice>();

        /// <summary>
        /// I dont know if this method should be part of the implemented datacontext or somewhere else
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void SetModified<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}