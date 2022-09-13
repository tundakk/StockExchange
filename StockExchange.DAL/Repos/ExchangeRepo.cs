namespace StockExchange.DAL.Repos
{
    using System.Linq;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;

    /// <summary>
    /// Repository class for Exchange.
    /// </summary>
    public class ExchangeRepo : BaseRepo<Exchange>, IExchangeRepo
    {
        /// <summary>
        /// Default constructor for ExchangeRepo.
        /// </summary>
        /// <param name="deliveryContext">Public readonly property on the BaseRepo class.</param>
        public ExchangeRepo(DataContext deliveryContext) : base(deliveryContext)
        {
        }

        //GET

        /// <summary>
        /// Gets all entities from Exchange table.
        /// </summary>
        /// <returns>returns a populated list of type Exchange, of all entities in the database.</returns>
        public override IQueryable<Exchange> GetAll()
        {
            return DeliveryContext.Exchanges; //does this return a list of Exhange objects?
        }

        /// <summary>
        /// Get Exchange object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated exchange object by matching ID.</returns>
        /// <exception cref="ArgumentException"></exception>
        public Exchange? GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("GetById - ID must be greater than 0");
            }

            return DeliveryContext.Exchanges.Find(id);
        }

        /// <summary>
        /// It gets an exchange from repo by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>a populated exchange object.</returns>
        /// <exception cref="ArgumentException"></exception>
        public Exchange? GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("GetByName - name must not be null or empty.");
            }

            return this.GetAll()
                .FirstOrDefault(s => string
                .Equals(s.Name.ToLower(), name.ToLower()));
        }

        // POST

        /// <summary>
        /// Inserts an exchange into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the populated exchange that was inserted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override Exchange Insert(Exchange entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - Exchange must not be null");
            }

            DeliveryContext.Exchanges.Add(entity);
            return entity;
        }

        // DELETE

        /// <summary>
        /// Deletes an exchange.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the exchange that was deleted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override Exchange Delete(Exchange entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - Exchange must not be null");
            }

            DeliveryContext.Exchanges.Remove(entity);
            return entity;
        }
    }
}
