namespace StockExchange.Domain.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Domain model for Exchange.
    /// </summary>
    public class ExchangeModel
    {
        /// <summary>
        /// Primary Key of Exchange object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Human readable name of the Exchange object.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// If exchange object is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// List of StockSymbols attached to the exchange object.
        /// </summary>
        public virtual ICollection<StockSymbolModel> StockSymbols { get; set; } = null!; //1:n //should it be new list? or nullable?
    }
}
