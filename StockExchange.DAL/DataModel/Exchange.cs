namespace StockExchange.DAL.DataModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// DAL datamodel for Exchange.
    /// </summary>
    public class Exchange
    {
        /// <summary>
        /// Primary Key of Exchange object.
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Human readable name of the Exchange object.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// If exchange object is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// List of StockSymbols attached to the exchange object.
        /// </summary>
        public ICollection<StockSymbol> StockSymbols { get; set; } = null!; //1:n //should it be new list? or nullable?
    }
}
