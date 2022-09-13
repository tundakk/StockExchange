namespace StockExchange.DAL.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// DAL datamodel for EodPrice.
    /// </summary>
    public class EodPrice
    {
        /// <summary>
        /// Primary Key of EodPrice object.
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Property. Date created. Default time is datetime.Now.
        /// </summary>
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Property. Close price of entity in decimal.
        /// </summary>
        [Required]
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// The parent object.
        /// </summary>
        [Required]
        public StockSymbol? StockSymbol { get; set; } // n-1

        /// <summary>
        /// The ID of the parent StockSymbol.
        /// </summary>
        [Required]
        public int StockSymbolId { get; set; }
    }
}
