namespace StockExchange.DAL.DataModel
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DataContext file. inherits from DbContext.
    /// Im using lampda Set to remove possible null value from the constructor.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default constructor for the DataContext file.
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// test constructor. Im unsure if this breaks anything. created because moq is not good with literal classes. it wants an empty constructor implemented.
        /// </summary>
        public DataContext()
        {
        }

        /// <summary>
        /// dataseeding. On model creation it seeds 3 rows in every table.
        /// </summary>
        /// <param name="modelBuilder"></param>
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
                },
                new Exchange
                {
                    ID = 3,
                    Name = "Bombay Stock Exchange",
                    IsActive = false,
                });
            modelBuilder.Entity<StockSymbol>().HasData(
                new StockSymbol
                {
                    ID = 1,
                    CompanyName = "Straton Oakmount",
                    Ticker = DateTime.Now,
                    IsActive = false,
                    ExchangeId = 1,
                },
                new StockSymbol
                {
                    ID = 2,
                    CompanyName = "Apple",
                    Ticker = DateTime.Now,
                    IsActive = true,
                    ExchangeId = 2,
                },
                new StockSymbol
                {
                    ID = 3,
                    CompanyName = "Alphabet",
                    Ticker = DateTime.Now,
                    IsActive = true,
                    ExchangeId = 3,
                });

            modelBuilder.Entity<EodPrice>().HasData(
                new EodPrice
                {
                    ID = 1,
                    Date = DateTime.Now,
                    ClosePrice = 10.14m,
                    StockSymbolId = 1,
                },
                new EodPrice
                {
                    ID = 2,
                    Date = DateTime.Now,
                    ClosePrice = 20.14m,
                    StockSymbolId = 2,
                },
                new EodPrice
                {
                    ID = 3,
                    Date = DateTime.Now,
                    ClosePrice = 30.14m,
                    StockSymbolId = 3,
                });
        }

        /// <summary>
        /// creates a table and relation for Exchanges.
        /// </summary>
        public virtual DbSet<Exchange> Exchanges => Set<Exchange>();

        /// <summary>
        /// creates a table and relation for StockSymbols.
        /// </summary>
        public virtual DbSet<StockSymbol> StockSymbols => Set<StockSymbol>();

        /// <summary>
        /// creates a table and relation for EodPrices.
        /// </summary>
        public virtual DbSet<EodPrice> EodPrices => Set<EodPrice>();

        /// <summary>
        /// Sets database state to the modified state.
        /// I dont know if this method should be part of the implemented datacontext or somewhere else.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void SetModified<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
