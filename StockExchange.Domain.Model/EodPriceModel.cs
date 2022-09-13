namespace StockExchange.Domain.Model
{
    using System;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Domain model for EodPrice.
    /// </summary>
    public class EodPriceModel
    {
        /// <summary>
        /// Primary Key of EodPrice object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Property. Date created. Default time is datetime.Now.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Property. Close price of entity in decimal.
        /// </summary>
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// The parent object.
        /// </summary>
        [JsonIgnore]
        public StockSymbolModel? StockSymbolModel { get; set; } // n-1

        /// <summary>
        /// The ID of the parent StockSymbol.
        /// </summary>
        public int StockSymbolId { get; set; }
    }
}
